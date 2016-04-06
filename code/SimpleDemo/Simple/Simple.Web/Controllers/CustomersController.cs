﻿using System.Threading.Tasks;
using System.Web.Http;
using Simple.Contracts;
using Simple.Domain;

namespace Simple.Web.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateCustomer(Customer customer)
        {
            var result = await _service.CreateCustomer(customer);
            return Ok(result);
        }
    }
}