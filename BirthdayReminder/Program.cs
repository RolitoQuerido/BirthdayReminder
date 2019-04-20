using Autofac;
using BirthdayReminder.IoC;
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
            var container = Factory.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
