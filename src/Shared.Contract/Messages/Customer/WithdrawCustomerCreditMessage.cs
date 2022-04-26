namespace Shared.Contract.Messages.Customer;

public interface WithdrawCustomerCreditMessage
{
    Guid CorrelationId { get; }
    decimal Credit { get; }
    int CustomerId { get; }
    int OrderId { get; }
}
