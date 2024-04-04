using System;
using BlazorShared.Attributes;

namespace BlazorShared.Models;

[Endpoint(Name = "order")]
public class Order
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public string State { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
}
