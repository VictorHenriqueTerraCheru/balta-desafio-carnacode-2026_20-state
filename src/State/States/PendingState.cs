using States;

namespace States
{
    public class PendingState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"Pagamento confirmado! Total: R$ {order.TotalAmount:N2}");
            order.SetState(new PaidState());
        }

        public void Ship(Order order, string trackingCode)
            => Console.WriteLine("Pedido ainda não foi pago!");

        public void Deliver(Order order)
            => Console.WriteLine("Pedido ainda não foi enviado!");

        public void Cancel(Order order)
        {
            Console.WriteLine("Pedido cancelado. Nenhuma cobrança realizada.");
            order.SetState(new CancelledState());
        }

        public void RequestReturn(Order order)
            => Console.WriteLine("Pedido ainda não foi entregue. Use cancelamento.");

        public string GetStateName() => "Pendente";
    }
}