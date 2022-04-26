namespace Shared.Contract.Events.Product;

public interface ProductCreatedEvent
{
    int ProductId { get; }
    int Count { get; }
    decimal Price { get; }
}
