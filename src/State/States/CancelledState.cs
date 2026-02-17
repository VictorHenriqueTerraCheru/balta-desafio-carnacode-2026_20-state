
namespace States
{
    public class CancelledState : IOrderState
    {
        public void ProcessPayment(Order order)
            => Console.WriteLine("Pedido cancelado. Crie novo pedido.");

        public void Ship(Order order, string trackingCode)
            => Console.WriteLine("Pedido cancelado não pode ser enviado!");

        public void Deliver(Order order)
            => Console.WriteLine("Pedido cancelado não pode ser entregue!");

        public void Cancel(Order order)
            => Console.WriteLine("Pedido já está cancelado!");

        public void RequestReturn(Order order)
            => Console.WriteLine("Pedido cancelado não pode ser devolvido!");

        public string GetStateName() => "Cancelado";
    }
}