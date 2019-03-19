using BirthdayReminder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayReminder.IoC
{
    public static class Factory
    {
        public static IPerson CreatePerson()
        {
            return new Person();
        }
    }
}
