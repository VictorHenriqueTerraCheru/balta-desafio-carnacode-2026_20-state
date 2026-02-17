namespace States
{
    public interface IOrderState
    {
        void ProcessPayment(Order order);
        void Ship(Order order, string trackingCode);
        void Deliver(Order order);
        void Cancel(Order order);
        void RequestReturn(Order order);
        string GetStateName();
    }
}