using Autofac;
using BirthdayReminder.Models;
using BirthdayReminder.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BirthdayReminder.IoC
{
    public static class Factory
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Process>().As<IProcess>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(BirthdayReminder)))
                .Where(t => t.Namespace.Contains("Models"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(BirthdayReminder)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
