using BlazorShared.Attributes;

namespace BlazorShared.Models;

[Endpoint(Name = "order-item")]
public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }

}
