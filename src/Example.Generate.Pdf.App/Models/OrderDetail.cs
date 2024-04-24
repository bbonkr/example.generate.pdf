namespace Example.Generate.Pdf.App.Models;

public class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public double TotalPrice { get => Price * Quantity; }

    public string? Note { get; set; }
}
