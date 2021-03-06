﻿using AutoMapper;
using Domain.Commands;
using Domain.Entities;
using Domain.Validations;
using MediatR;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Response;
using System.Threading.Tasks;

namespace Restful.Login.Application.Services
{
    public class CustomerService : Notifiable, ICustomerService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> Add(CustomerCreateCommand command)
        {
            var customer = await _mediator.Send(command);
            return _mapper.Map<Customer, CustomerResponse>(customer);
        }
    }
}
