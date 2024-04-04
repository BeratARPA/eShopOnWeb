using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderService
{
    Task ChangeStatus(int orderId, string status);
    Task<List<Order>> ListPaged(int pageSize);
    Task<List<Order>> List();
}
