using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderItemService : IOrderItemService
{   
    private readonly HttpService _httpService;
    private readonly ILogger<OrderItemService> _logger;

    public OrderItemService(HttpService httpService,
        ILogger<OrderItemService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<OrderItem>> GetByOrderId(int orderId)
    {
        var itemGetTask = _httpService.HttpGet<PagedOrderItemResponse>($"order-item/{orderId}");
        await Task.WhenAll(itemGetTask);
        var orders = itemGetTask.Result.OrderItems;
        return orders;
    }

    public async Task<List<OrderItem>> ListPaged(int pageSize)
    {
        _logger.LogInformation("Fetching order items from API.");

        var itemListTask = _httpService.HttpGet<PagedOrderItemResponse>($"order-item?PageSize=10");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.OrderItems;

        return items;
    }

    public async Task<List<OrderItem>> List()
    {
        _logger.LogInformation("Fetching order items from API.");

        var itemListTask = _httpService.HttpGet<PagedOrderItemResponse>($"order-item");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.OrderItems;

        return items;
    }
}
