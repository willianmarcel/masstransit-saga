namespace Shared.Contract.Events.Product;

public interface ProductUpdatedEvent
{
    int ProductId { get; }
    int Count { get; }
    decimal Price { get; }
}
public interface ProductsUpdatedEvent
{
    IList<ProductUpdatedEvent> ProductUpdatedEvents { get; }
}
