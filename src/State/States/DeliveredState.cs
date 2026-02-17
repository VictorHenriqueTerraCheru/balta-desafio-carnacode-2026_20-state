
namespace States
{
    public class DeliveredState : IOrderState
    {
        public void ProcessPayment(Order order)
            => Console.WriteLine("Pedido já foi pago!");

        public void Ship(Order order, string trackingCode)
            => Console.WriteLine("Pedido já foi entregue!");

        public void Deliver(Order order)
            => Console.WriteLine($"Pedido já foi entregue em {order.DeliveredDate:dd/MM/yyyy}!");

        public void Cancel(Order order)
            => Console.WriteLine("Pedido já entregue. Solicite devolução se necessário.");

        public void RequestReturn(Order order)
        {
            var days = (DateTime.Now - order.DeliveredDate!.Value).Days;

            if (days <= 7)
            {
                Console.WriteLine($"Devolução aprovada! Reembolso: R$ {order.TotalAmount:N2}");
                order.SetState(new ReturnedState());
            }
            else
                Console.WriteLine($"Prazo de devolução expirado ({days} dias)!");
        }

        public string GetStateName() => "Entregue";
    }
}