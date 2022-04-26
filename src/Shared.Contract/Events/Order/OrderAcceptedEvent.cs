namespace Shared.Contract.Events.Order;

public interface OrderAcceptedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
}
