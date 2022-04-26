using MassTransit;

namespace OrderApi.Saga.SubmitOrderSagas;

public class OrderState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public State CurrentState { get; set; }
    public int OrderId { get; set; }
}
