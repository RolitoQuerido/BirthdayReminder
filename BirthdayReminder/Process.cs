using BirthdayReminder.Models;
using BirthdayReminder.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BirthdayReminder
{
    public class Process : IProcess
    {
        public IEmailManager _emailMgr;
        public IDocumentManager _documentMgr;
        public ILogger _log;

        public Process(IEmailManager emailMgr, IDocumentManager documentMgr, ILogger log)
        {
            _emailMgr = emailMgr;
            _documentMgr = documentMgr;
            _log = log;
        }

        public void ProcessData()
        {
            var birthdaysJson = _documentMgr.ReadFile(ConfigurationManager.AppSettings["birthdayDocPath"]);
            var personList = JsonConvert.DeserializeObject<List<Person>>(birthdaysJson);
            var birthdays = GetTodaysBirthdayList(personList);

            if (birthdays.Any())
            {
                var names = string.Join(", ", birthdays.Select(b => b.Name));
                if (birthdays.Count() > 1)
                {
                    var lastCommaIndex = names.LastIndexOf(",");
                    names = names.Remove(lastCommaIndex, 1).Insert(lastCommaIndex, " y");
                }

                var body = birthdays.Count == 1 ?
                    _documentMgr.ReadFile("Templates/Single.html").Replace("{name}", names) :
                    _documentMgr.ReadFile("Templates/Many.html").Replace("{name}", names);

                _emailMgr.SendBirthdayEmail(body);
                _log.Log("Birthdays: " + names);
            }
            else
            {
                _log.Log("No birthdays today");
            }
        }

        private static List<Person> GetTodaysBirthdayList(List<Person> personList)
        {
            var birthdays = personList.Where(p => p.Birthday.Month == DateTime.Today.Month && p.Birthday.Day == DateTime.Today.Day && p.SendEmail).ToList();

            if (DateTime.Today.Month == 2 && DateTime.Today.Day == 28 && !DateTime.IsLeapYear(DateTime.Today.Year))
                birthdays.Concat(personList.Where(p => p.Birthday.Month == 2 && p.Birthday.Day == 29 && p.SendEmail));
            return birthdays;
        }
    }
}
