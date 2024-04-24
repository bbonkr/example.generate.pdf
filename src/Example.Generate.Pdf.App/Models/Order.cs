namespace Example.Generate.Pdf.App.Models;

public class Order
{
    public Guid Id { get; set; }

    public Customer Customer { get; set; }

    public IEnumerable<OrderDetail> Details { get; set; } = Enumerable.Empty<OrderDetail>();
}
