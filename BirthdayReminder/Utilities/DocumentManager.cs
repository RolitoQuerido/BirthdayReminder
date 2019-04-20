using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BirthdayReminder.Utilities
{
    public class DocumentManager : IDocumentManager
    {
        public DocumentManager()
        {

        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string text)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
