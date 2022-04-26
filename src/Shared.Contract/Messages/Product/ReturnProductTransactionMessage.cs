namespace Shared.Contract.Messages.Product;

public interface ReturnProductTransactionMessage
{
    IList<ProductBasket> ProductBaskets { get; }
}
