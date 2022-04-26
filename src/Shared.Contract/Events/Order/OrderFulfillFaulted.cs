namespace Shared.Contract.Events.Order;

public interface OrderFulfillFaulted
{
    int OrderId { get; }
}
