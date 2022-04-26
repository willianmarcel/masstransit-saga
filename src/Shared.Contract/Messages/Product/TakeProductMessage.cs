namespace Shared.Contract.Messages.Product;

public interface TakeProductMessage
{
    Guid CorrelationId { get; }
    int OrderId { get; }
}
