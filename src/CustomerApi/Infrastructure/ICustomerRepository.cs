using CustomerApi.Model;

namespace CustomerApi.Infrastructure;

public interface ICustomerRepository
{
    Task<Customer> Get(int id);
    Task<IEnumerable<Customer>> Get();
    Task<Customer> Insert(Customer customer);
    Task Delete(int id);
    Task Update(Customer customer);
}
