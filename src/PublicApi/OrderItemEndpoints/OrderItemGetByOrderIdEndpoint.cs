using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

/// <summary>
/// Get a Order Item by Id
/// </summary>
public class OrderItemGetByOrderIdEndpoint : IEndpoint<IResult, GetByIdOrderItemRequest, IRepository<Order>>
{
    public OrderItemGetByOrderIdEndpoint()
    {

    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-item/{orderId}",
            async (int orderId, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(new GetByIdOrderItemRequest(orderId), itemRepository);
            })
            .Produces<GetByIdOrderItemResponse>()
            .WithTags("OrderItemEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderItemRequest request, IRepository<Order> itemRepository)
    {
        var response = new GetByIdOrderItemResponse(request.CorrelationId());

        var spec = new OrderWithItemsByIdSpec(request.OrderId);
        var items = await itemRepository.FirstOrDefaultAsync(spec);

        if (items is null)
            return Results.NotFound();

        foreach (var item in items.OrderItems.ToList())
        {
            response.OrderItems.Add(new OrderItemDto
            {
                Id = item.Id,
                Name = item.ItemOrdered.ProductName,
                UnitPrice = item.UnitPrice * item.Units,
                Units = item.Units
            });
        }

        return Results.Ok(response);
    }
}
