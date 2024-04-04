using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

/// <summary>
/// List Order
/// </summary>
public class OrderListEndpoint : IEndpoint<IResult, IRepository<Order>>
{
    public OrderListEndpoint()
    {

    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order",
            async (IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(orderRepository);
            })
           .Produces<ListOrderResponse>()
           .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> orderRepository)
    {
        var response = new ListOrderResponse();

        var orders = await orderRepository.ListAsync();

        foreach (var order in orders)
        {
            var spec = new OrderWithItemsByIdSpec(order.Id);
            var items = await orderRepository.FirstOrDefaultAsync(spec);

            if (items is null)
                return Results.NotFound();

            var total = 0m;
            foreach (var item in items.OrderItems.ToList())
            {
                total += item.UnitPrice * item.Units;
            }

            response.Orders.Add(new OrderDto
            {
                Id = order.Id,
                BuyerId = order.BuyerId,
                OrderDate = order.OrderDate,
                State = order.State,
                Total = total
            });
        }

        return Results.Ok(response);
    }
}
