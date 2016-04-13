﻿using System.Threading.Tasks;
using MassTransit;
using Simple.CommandStack.Events;
using Simple.Contracts;

namespace Simple.Infrastructure.Consumers
{
    public class UpdateCustomerCondensedReadModelConsumer : IConsumer<ICustomerCreatedEvent>
    {
        private readonly IUpdateCustomerCondensedRepository _repository;

        public UpdateCustomerCondensedReadModelConsumer(IUpdateCustomerCondensedRepository repository)
        {
            _repository = repository;
        }

        public Task Consume(ConsumeContext<ICustomerCreatedEvent> context)
        {
            _repository.Update(context.Message);

            // TODO Do we have to return anything here??
            return null;
        }
    }
}