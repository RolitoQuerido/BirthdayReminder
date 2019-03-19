using System;

namespace BirthdayReminder.Models
{
    public interface IPerson
    {
        DateTime Birthday { get; set; }
        string Name { get; set; }
    }
}