namespace Shared.Contract.Messages.Order;

public interface FullfillOrderMessage
{
    int OrderId { get; }
    decimal Credit { get; }
    int CustomerId { get; }
}
