public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== State Pattern - Pedidos ===\n");

        Console.WriteLine(">>> Fluxo Normal\n");
        var order1 = new Order("ORD-001", 250.00m);
        order1.ProcessPayment();
        order1.Ship("BR123456789");
        order1.Deliver();
        order1.RequestReturn();
        order1.DisplayInfo();

        Console.WriteLine("\nOperações Inválidas\n");
        var order2 = new Order("ORD-002", 150.00m);
        order2.Ship("BR999");          // Não pago ainda!
        order2.ProcessPayment();
        order2.ProcessPayment();       // Já pago!
        order2.Cancel();               // Cancela após pagamento
        order2.ProcessPayment();       // Cancelado!
        order2.DisplayInfo();

        Console.WriteLine("\nhBenefícios\n");
        Console.WriteLine("ANTES: 6 estados x 5 métodos = 30 cases na Order");
        Console.WriteLine("DEPOIS: Order tem 0 switches! Delega pro estado atual!");
        Console.WriteLine("Novo estado? Só criar nova classe State!");
        Console.WriteLine("Nova operação? Adiciona na interface + implementa em cada State");
    }
}