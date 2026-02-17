using States;
public class Order
{
    public string OrderId { get; }
    public decimal TotalAmount { get; }
    public string? TrackingCode { get; set; }
    public DateTime? ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }

    private IOrderState _state;

    public Order(string orderId, decimal totalAmount)
    {
        OrderId = orderId;
        TotalAmount = totalAmount;
        _state = new PendingState();
        Console.WriteLine($"[{OrderId}] Criado | Estado: {_state.GetStateName()}");
    }

    public void SetState(IOrderState state)
    {
        _state = state;
        Console.WriteLine($"[{OrderId}] Estado: {_state.GetStateName()}");
    }

    // Delega tudo para o estado atual!
    public void ProcessPayment() => _state.ProcessPayment(this);
    public void Ship(string tracking) => _state.Ship(this, tracking);
    public void Deliver() => _state.Deliver(this);
    public void Cancel() => _state.Cancel(this);
    public void RequestReturn() => _state.RequestReturn(this);

    public void DisplayInfo()
    {
        Console.WriteLine($"\n=== {OrderId} ===");
        Console.WriteLine($"Total: R$ {TotalAmount:N2}");
        Console.WriteLine($"Estado: {_state.GetStateName()}");
        if (TrackingCode != null) Console.WriteLine($"Rastreamento: {TrackingCode}");
        if (ShippedDate != null) Console.WriteLine($"Enviado: {ShippedDate:dd/MM/yyyy}");
        if (DeliveredDate != null) Console.WriteLine($"Entregue: {DeliveredDate:dd/MM/yyyy}");
    }
}