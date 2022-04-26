namespace Shared.Contract.Events.Order;

public interface OrderTransactionAcceptedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
}
