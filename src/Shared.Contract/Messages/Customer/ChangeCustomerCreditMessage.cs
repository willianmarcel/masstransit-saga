namespace Shared.Contract.Messages.Customer;

public interface ChangeCustomerCreditMessage
{
    int CostomerId { get; }
    decimal Credit { get; }
}
