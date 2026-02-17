using States;

namespace States
{
    public class PaidState : IOrderState
    {
        public void ProcessPayment(Order order)
            => Console.WriteLine("Pedido já foi pago!");

        public void Ship(Order order, string trackingCode)
        {
            order.TrackingCode = trackingCode;
            order.ShippedDate = DateTime.Now;
            Console.WriteLine($"Pedido enviado! Rastreamento: {trackingCode}");
            order.SetState(new ShippedState());
        }

        public void Deliver(Order order)
            => Console.WriteLine("Pedido ainda não foi enviado!");

        public void Cancel(Order order)
        {
            Console.WriteLine($"Pedido cancelado. Reembolso de R$ {order.TotalAmount:N2} será processado.");
            order.SetState(new CancelledState());
        }

        public void RequestReturn(Order order)
            => Console.WriteLine("Pedido ainda não foi entregue. Use cancelamento.");

        public string GetStateName() => "Pago";
    }
}