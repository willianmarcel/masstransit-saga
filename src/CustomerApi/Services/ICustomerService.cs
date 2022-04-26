using CustomerApi.Dtos;

namespace CustomerApi.Services;

public interface ICustomerService
{
    Task AddCredit(decimal credit, int customerId);
    Task WithdrawCredit(decimal credit, int customerId);
    Task<int> CreateCustomer(CreateCustomerDto customer);
}
