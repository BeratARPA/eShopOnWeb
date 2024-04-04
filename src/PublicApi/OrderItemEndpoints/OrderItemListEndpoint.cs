using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderItemEndpoints;

/// <summary>
/// List Order Item
/// </summary>
public class OrderItemListEndpoint : IEndpoint<IResult, IRepository<OrderItem>>
{
    private readonly IMapper _mapper;

    public OrderItemListEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-item",
            async (IRepository<OrderItem> orderItemRepository) =>
            {
                return await HandleAsync(orderItemRepository);
            })
           .Produces<ListOrderItemResponse>()
           .WithTags("OrderItemEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<OrderItem> orderItemRepository)
    {
        var response = new ListOrderItemResponse();

        var items = await orderItemRepository.ListAsync();

        if (items is null)
            return Results.NotFound();

        foreach (var item in items)
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
