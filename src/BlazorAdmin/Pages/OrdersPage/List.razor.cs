﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Pages.OrderPage;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrdersPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }

    private List<Order> orders = new List<Order>();

    private Details DetailsComponent { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {           
            orders = await OrderService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private async void DetailsClick(int id)
    {
        await DetailsComponent.Open(id);
    }

    private async Task ReloadOrder()
    {
        orders = await OrderService.List();
        StateHasChanged();
    }
}
