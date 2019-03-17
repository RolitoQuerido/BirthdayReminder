using BirthdayReminder.Models;
using BirthdayReminder.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BirthdayReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BirthdayReminder App started!");

            Run();

            Console.WriteLine("BirthdayReminder App stoped!");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        private static void Run()
        {
            var documentMgr = new DocumentManager();
            string birthdaysJson = documentMgr.ReadFile(ConfigurationManager.AppSettings["birthdayDocPath"]);

            var personList = JsonConvert.DeserializeObject<List<Person>>(birthdaysJson);

            var birthdays = personList.Where(p => p.Birthday.Month == DateTime.Today.Month && p.Birthday.Day == DateTime.Today.Day).ToList();
            if (DateTime.Today.Month == 2 && DateTime.Today.Day == 28 && !DateTime.IsLeapYear(DateTime.Today.Year))
                birthdays.Concat(personList.Where(p => p.Birthday.Month == 2 && p.Birthday.Day == 29));

            if (birthdays.Any())
            {
                var emailMgr = new EmailManager();
                var names = string.Join(", ", birthdays.Select(b => b.Name));
                emailMgr.SendBirthdayEmail(names);
                Console.WriteLine(DateTime.Today.ToShortDateString() + " - Birthdays: " + names);
            }
            else
            {
                Console.WriteLine(DateTime.Today.ToShortDateString() + " - No birthdays today");
            }
        }
    }
}
