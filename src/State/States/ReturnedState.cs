
namespace States
{
    public class ReturnedState : IOrderState
    {
        public void ProcessPayment(Order order)
            => Console.WriteLine("Pedido devolvido. Operação inválida!");

        public void Ship(Order order, string trackingCode)
            => Console.WriteLine("Pedido devolvido. Operação inválida!");

        public void Deliver(Order order)
            => Console.WriteLine("Pedido devolvido. Operação inválida!");

        public void Cancel(Order order)
            => Console.WriteLine("Pedido devolvido. Operação inválida!");

        public void RequestReturn(Order order)
            => Console.WriteLine("Devolução já processada!");

        public string GetStateName() => "Devolvido";
    }
}