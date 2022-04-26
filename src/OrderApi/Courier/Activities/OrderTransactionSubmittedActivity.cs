using MassTransit;
using OrderApi.Saga.SubmitOrderTransactionalSaga;
using Shared.Contract.Constants;
using Shared.Contract.Events.Order;
using Shared.Contract.Messages.Order;

namespace OrderApi.Courier.Activities;

public class OrderTransactionSubmittedActivity : IStateMachineActivity<OrderTransactionState, OrderTransactionSubmittedEvent>
{

    private readonly ILogger<OrderTransactionSubmittedActivity> logger;

    public OrderTransactionSubmittedActivity(ILogger<OrderTransactionSubmittedActivity> logger)
    {
        this.logger = logger;
    }

    public void Accept(StateMachineVisitor visitor)
    {
        visitor.Visit(this);
    }

    public async Task Execute(BehaviorContext<OrderTransactionState, OrderTransactionSubmittedEvent> context, IBehavior<OrderTransactionState, OrderTransactionSubmittedEvent> next)
    {
        var sendEndpoint = await context.GetSendEndpoint(QueueNames.GetMessageUri(nameof(FullfillOrderMessage)));

        logger.LogInformation($"Order Transaction activity for sendEndpoint {sendEndpoint} will be called");

        await sendEndpoint.Send<FullfillOrderMessage>(new
        {
            OrderId = context.Data.OrderId,
            Credit = context.Data.Credit,
            CustomerId = context.Data.CustomerId
        });
    }

    public Task Faulted<TException>(BehaviorExceptionContext<OrderTransactionState, OrderTransactionSubmittedEvent, TException> context, IBehavior<OrderTransactionState, OrderTransactionSubmittedEvent> next) where TException : Exception
    {
        return next.Faulted(context);
    }

    public void Probe(ProbeContext context)
    {
        context.CreateScope("submit-order");
    }
}