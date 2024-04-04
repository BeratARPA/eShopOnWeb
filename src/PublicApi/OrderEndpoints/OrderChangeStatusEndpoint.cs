using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

/// <summary>
/// List Order
/// </summary>
public class OrderChangeStatusEndpoint : IEndpoint<IResult, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderChangeStatusEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order/{orderId}/state/{newStatus}",
            async (IRepository<Order> orderRepository, int orderId, string newStatus) =>
            {
                return await HandleAsync(orderRepository, orderId, newStatus);
            })
           .Produces<ListOrderChangeStatusResponse>()
           .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> orderRepository, int orderId, string newStatus)
    {
        var response = new ListOrderChangeStatusResponse();
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return Results.NotFound();

        order.State = newStatus;

        await orderRepository.UpdateAsync(order);

        response.Order = _mapper.Map<OrderDto>(order);

        return Results.Ok(response);
    }

    public async Task<IResult> HandleAsync(IRepository<Order> request)
    {
        return Results.Ok();
    }
}
