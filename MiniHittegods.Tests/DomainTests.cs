using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Services;
using Xunit;

namespace XDomainTests;

public class DomainTests
{
    [Fact]
    public void FoundItemAvailable()
    {
        var target = new FoundItem();

        var status = target.Status;

        Assert.Equal(ItemStatus.Available, status);
    }

    [Fact]
    public void FoundItemClaim()
    {
        var target = new FoundItem();

        target.ClaimItem();

        var status = target.Status;

        Assert.Equal(ItemStatus.Claimed, status);
    }

    [Fact]
    public void FoundItemReturn()
    {
        var target = new FoundItem();

        target.ClaimItem();
        target.ReturnItem();

        var status = target.Status;

        Assert.Equal(ItemStatus.Returned, status);
    }

    [Fact]
    public void FoundItemDelete()
    {
        var target = new FoundItem();

        target.RemoveItem();

        var status = target.Status;

        Assert.Equal(ItemStatus.Deleted, status);
    }

    [Fact]
    public void FoundItemTestNewItem()
    {
        var item = new FoundItems
        {
            Id = 1,
            Title = "test",
            Category = "action",
        };

        FoundItemsService.AddItem(item);

        Assert.NotEmpty(FoundItemsService._repository.GetAll());
    }

    [Fact]
    public void FoundItemTestRemoveItem()
    {
        var item = new FoundItems
        {
            Id = 1,
            Title = "test",
            Category = "action",
        };

        FoundItemsService.AddItem(item);

        FoundItemsService.RemoveItem(item);

        Assert.Empty(FoundItemsService._repository.GetAll());
    }

    [Fact]
    public void FoundItemTestGetAllItem()
    {
        var itemOne = new FoundItems
        {
            Id = 1,
            Title = "testOne",
            Category = "action",
        };
        var itemTwo = new FoundItems
        {
            Id = 2,
            Title = "testTwo",
            Category = "romance",
        };

        FoundItemsService.AddItem(itemOne);
        FoundItemsService.AddItem(itemTwo);

        Assert.NotEmpty(FoundItemsService._repository.GetAll());
    }

    [Fact]
    public void FoundItemTestGetByIdItem()
    {
        var itemOne = new FoundItems
        {
            Id = 1,
            Title = "testOne",
            Category = "action",
        };
        FoundItemsService.AddItem(itemOne);
        var result = FoundItemsService.GetByIdItem(1);

        Assert.Equal(itemOne, result);
    }
}
