using CustomerApi.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Services;
using Shared.Contract.Events.Customer;

namespace CustomerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly IPublishEndpoint publishEndpoint;

    public CustomerController(ICustomerService customerService, IPublishEndpoint publishEndpoint)
    {
        this.customerService = customerService;
        this.publishEndpoint = publishEndpoint;
    }

    public async Task<string> Get()
    {
        await Task.CompletedTask;
        return "customer";
    }

    [HttpPost("AddCredit")]
    public Task AddCustomerCredit([FromBody] AddCreditDto addCreditDto)
    {

        return customerService.AddCredit(addCreditDto.Credit, addCreditDto.CustomerId);
    }

    [HttpPost("WithdrawCredit")]
    public Task WithdrawCredit([FromBody] WithdrawCreditDto withdrawCreditDto)
    {

        return customerService.WithdrawCredit(withdrawCreditDto.Credit, withdrawCreditDto.CustomerId);
    }

    [HttpPost("CreateCredit")]
    public async Task<int> CreateCredit([FromBody] CreateCustomerDto customer)
    {
        var customerId = await customerService.CreateCustomer(customer);
        await publishEndpoint.Publish<CustomerCreatedEvent>(new
        {
            CustomerId = customerId,
            FullName = customer.FullName
        });
        return customerId;
    }
}
