﻿using System;
using System.Threading.Tasks;
using MassTransit;
using Simple.CommandStack.Requests;
using Simple.CommandStack.Responses;
using Simple.Contracts;

namespace Simple.Infrastructure.Consumers
{
    public class GetCustomerConsumer : IConsumer<GetCustomerRequest>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerConsumer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<GetCustomerRequest> context)
        {
            try
            {
                await context.RespondAsync(new GetCustomerResponse
                {
                    Customer = _repository.FindById(context.Message.CustomerId),
                    Message = "ok",
                    ResponseId = context.Message.CustomerId
                });
            }
            catch (Exception exc)
            {
                await
                    context.RespondAsync(new GetCustomerResponse
                    {
                        ResponseId = context.Message.Id,
                        Message = "Failed" + Environment.NewLine + exc.Message
                    });
                throw;
            }
        }
    }
}