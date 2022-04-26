namespace Shared.Contract.Messages.Customer;

public interface ReturnCustomerCreditMessage
{
    int CustomerId { get; }
    decimal Credit { get; }
}
