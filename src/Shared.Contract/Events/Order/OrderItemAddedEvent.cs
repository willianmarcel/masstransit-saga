namespace Shared.Contract.Events.Order;

public interface OrderItemAddedEvent
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}
