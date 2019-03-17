using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BirthdayReminder.Utilities
{
    public class DocumentManager
    {
        public DocumentManager()
        {

        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
