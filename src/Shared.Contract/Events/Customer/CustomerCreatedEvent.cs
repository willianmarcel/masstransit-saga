namespace Shared.Contract.Events.Customer;

public interface CustomerCreatedEvent
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
}
