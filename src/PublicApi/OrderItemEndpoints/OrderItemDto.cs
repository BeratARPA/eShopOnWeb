﻿namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

public class OrderItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal UnitPrice { get;  set; }
    public int Units { get;  set; }

}
