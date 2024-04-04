using System.Collections.Generic;

namespace BlazorShared.Models;

public class PagedOrderItemResponse
{
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public int PageCount { get; set; } = 0;
}
