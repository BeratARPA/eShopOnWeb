using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderItemService
{
    Task<List<OrderItem>> GetByOrderId(int orderId);
    Task<List<OrderItem>> ListPaged(int pageSize);
    Task<List<OrderItem>> List();
}
