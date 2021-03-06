﻿using Autofac;
using Simple.Eventstore;

namespace Simple.Infrastructure.Modules
{
    public class EventStoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MsSqlEventStore).Assembly).AsImplementedInterfaces();
        }
    }
}