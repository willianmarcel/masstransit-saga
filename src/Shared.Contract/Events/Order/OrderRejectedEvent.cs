namespace Shared.Contract.Events.Order;

public interface OrderRejectedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    string Reason { get; }
}
