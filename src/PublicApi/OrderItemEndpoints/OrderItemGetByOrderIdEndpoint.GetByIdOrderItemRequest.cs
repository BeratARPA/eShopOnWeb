namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

public class GetByIdOrderItemRequest : BaseRequest
{
    public int OrderId { get; init; }

    public GetByIdOrderItemRequest(int orderId)
    {
        OrderId = orderId;
    }
}
