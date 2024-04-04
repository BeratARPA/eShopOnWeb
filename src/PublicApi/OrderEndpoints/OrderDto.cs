using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{
    public int Id { get; set; }
    public string BuyerId { get;  set; }
    public string State { get;  set; }
    public DateTimeOffset OrderDate { get;  set; } = DateTimeOffset.Now;
    public decimal Total { get;  set; }
}
