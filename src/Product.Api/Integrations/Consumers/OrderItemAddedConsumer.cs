using MassTransit;
using ProductApi.Services;
using Shared.Contract.Events.Order;

namespace ProductApi.Integrations.Consumers;

public class OrderItemAddedConsumer : IConsumer<OrderItemAddedEvent>
{
    private readonly IProductService productService;

    public OrderItemAddedConsumer(IProductService productService)
    {
        this.productService = productService;
    }
    public Task Consume(ConsumeContext<OrderItemAddedEvent> context)
    {
        return productService.TakeProduct(context.Message.Count, context.Message.ProductId);
    }
}
