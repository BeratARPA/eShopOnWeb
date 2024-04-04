using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(HttpService httpService,
        ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<Order>> ListPaged(int pageSize)
    {
        _logger.LogInformation("Fetching order from API.");

        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"order?PageSize=10");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.Orders;

        return items;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching order from API.");

        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"order");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.Orders;

        return items;
    }

    public async Task ChangeStatus(int orderId, string status)
    {
        _logger.LogInformation($"Changing order status for order with ID {orderId} to Approved.");

        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"order/{orderId}/state/{status}");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.Orders;
    }
}
