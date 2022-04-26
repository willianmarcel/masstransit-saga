namespace Shared.Contract.Events.Order;

public interface OrderTransactionSubmittedEvent
{
    int OrderId { get; }
    Guid CorrelationId { get; }
    decimal Credit { get; }
    int CustomerId { get; }
}
