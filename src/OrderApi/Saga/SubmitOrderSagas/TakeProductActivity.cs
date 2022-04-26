using MassTransit;
using Shared.Contract.Events.Order;

namespace OrderApi.Saga.SubmitOrderSagas;

public class TakeProductActivity : IStateMachineActivity<OrderState, OrderAcceptedEvent>
{
    public TakeProductActivity()
    {

    }
    public void Accept(StateMachineVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public Task Execute(BehaviorContext<OrderState, OrderAcceptedEvent> context, IBehavior<OrderState, OrderAcceptedEvent> next)
    {
        throw new NotImplementedException();
    }

    public Task Faulted<TException>(BehaviorExceptionContext<OrderState, OrderAcceptedEvent, TException> context, IBehavior<OrderState, OrderAcceptedEvent> next) where TException : Exception
    {
        throw new NotImplementedException();
    }

    public void Probe(ProbeContext context)
    {
        throw new NotImplementedException();
    }
}
