using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BirthdayReminder.Utilities
{
    public class Logger : ILogger
    {
        public IDocumentManager _documentMgr;
        public Logger(IDocumentManager documentMgr)
        {
            _documentMgr = documentMgr;
        }

        public void Log(string text)
        {
            text = DateTime.Now.ToString() + " - " + text;
            _documentMgr.WriteFile(ConfigurationManager.AppSettings["logDocPath"], text);
        }
    }
}
