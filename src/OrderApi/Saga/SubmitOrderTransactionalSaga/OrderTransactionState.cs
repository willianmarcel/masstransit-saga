using MassTransit;

namespace OrderApi.Saga.SubmitOrderTransactionalSaga
{
    public class OrderTransactionState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State? CurrentState { get; set; }
        public int OrderId { get; set; }
    }
}
