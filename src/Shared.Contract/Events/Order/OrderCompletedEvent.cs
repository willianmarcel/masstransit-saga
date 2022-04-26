namespace Shared.Contract.Events.Order;

public interface OrderCompletedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
}
