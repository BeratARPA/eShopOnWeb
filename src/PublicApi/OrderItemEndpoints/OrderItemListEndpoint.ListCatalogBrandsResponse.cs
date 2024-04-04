using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

public class ListOrderItemResponse : BaseResponse
{
    public ListOrderItemResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListOrderItemResponse()
    {
    }

    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}
