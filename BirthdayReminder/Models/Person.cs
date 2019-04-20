using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayReminder.Models
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? FirstWorkDay { get; set; }
        public bool SendEmail { get; set; }

        public Person()
        {

        }
    }
}
