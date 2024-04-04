using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ListOrderChangeStatusResponse : BaseResponse
{
    public ListOrderChangeStatusResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListOrderChangeStatusResponse()
    {
    }

    public OrderDto Order { get; set; } = new OrderDto();
}
