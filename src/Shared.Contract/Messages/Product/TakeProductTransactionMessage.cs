namespace Shared.Contract.Messages.Product;

public interface TakeProductTransactionMessage
{
    IList<ProductBasket> ProductBaskets { get; }
}
public interface ProductBasket
{
    int ProductId { get; }
    int Count { get; }
}
