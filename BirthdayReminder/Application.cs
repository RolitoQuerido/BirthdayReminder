using BirthdayReminder.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayReminder
{
    public class Application : IApplication
    {
        IProcess _process;
        ILogger _log;

        public Application(IProcess process, ILogger log)
        {
            _process = process;
            _log = log;
        }

        public void Run()
        {
            _log.Log("BirthdayReminder App started!");

            try
            {
                _process.ProcessData();
            }
            catch (Exception e)
            {
                _log.Log("ErrorMessage: " + e.Message + " | StackTrace: " + e.StackTrace);
            }

            _log.Log("BirthdayReminder App stoped!");
        }
    }
}
