namespace Shared.Contract.Events.Order;

public interface OrderSubmittedEvent
{
    int OrderId { get; }
    Guid CorrelationId { get; }
    decimal Credit { get; }
    int CustomerId { get; }
}
