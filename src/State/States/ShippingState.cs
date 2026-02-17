using States;

namespace States
{
    public class ShippedState : IOrderState
    {
        public void ProcessPayment(Order order)
            => Console.WriteLine("Pedido já foi pago!");

        public void Ship(Order order, string trackingCode)
            => Console.WriteLine($"Pedido já foi enviado em {order.ShippedDate:dd/MM/yyyy}!");

        public void Deliver(Order order)
        {
            order.DeliveredDate = DateTime.Now;
            Console.WriteLine($"Pedido entregue! Data: {order.DeliveredDate:dd/MM/yyyy HH:mm}");
            order.SetState(new DeliveredState());
        }

        public void Cancel(Order order)
            => Console.WriteLine("Pedido já enviado. Use processo de devolução.");

        public void RequestReturn(Order order)
            => Console.WriteLine("Aguarde a entrega para solicitar devolução.");

        public string GetStateName() => "Enviado";
    }
}