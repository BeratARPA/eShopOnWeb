using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

public class GetByIdOrderItemResponse : BaseResponse
{
    public GetByIdOrderItemResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdOrderItemResponse()
    {
    }

    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}
