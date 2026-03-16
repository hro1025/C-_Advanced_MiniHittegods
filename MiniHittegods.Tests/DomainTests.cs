using Microsoft.AspNetCore.Razor.Language;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Interfaces;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;
using MiniHittegods.Domain.Services;
using Xunit;

namespace XDomainTests;

public class DomainTests
{
    private readonly Repository<FoundItemsModel> _repository = new();
    private readonly FoundItemsService _service;

    public DomainTests()
    {
        _service = new FoundItemsService(_repository);
    }

    [Fact]
    public void FoundItemAvailableTest()
    {
        var target = new FoundItem();

        var status = target.Status;

        Assert.Equal(Status.Available, status);
    }

    [Fact]
    public void FoundItemClaimTest()
    {
        var target = new FoundItem();

        target.ClaimItem();

        var status = target.Status;

        Assert.Equal(Status.Claimed, status);
    }

    [Fact]
    public void FoundItemReturnTest()
    {
        var target = new FoundItem();

        target.ClaimItem();
        target.ReturnItem();

        var status = target.Status;

        Assert.Equal(Status.Available, status);
    }

    [Fact]
    public void FoundItemDeleteTest()
    {
        var target = new FoundItem();

        target.RemoveItem();

        var status = target.Status;

        Assert.Equal(Status.Deleted, status);
    }

    [Fact]
    public void FoundItemNewItemTest()
    {
        var item = new FoundItemsModel
        {
            Id = 1,
            Title = "test",
            Category = "action",
        };
        _service.AddItem(item);

        Assert.NotEmpty(_service.GetAll());
    }

    [Fact]
    public void FoundItemRemoveItemTest()
    {
        var item = new FoundItemsModel
        {
            Id = 1,
            Title = "test",
            Category = "action",
        };

        _service.AddItem(item);

        Assert.NotEmpty(_service.GetAll());

        _service.RemoveItem(item);

        Assert.Empty(_service.GetAll());
    }

    [Fact]
    public void FoundItemGetAllItemTest()
    {
        var itemOne = new FoundItemsModel
        {
            Id = 1,
            Title = "testOne",
            Category = "action",
        };
        var itemTwo = new FoundItemsModel
        {
            Id = 2,
            Title = "testTwo",
            Category = "romance",
        };
        _service.AddItem(itemOne);
        _service.AddItem(itemTwo);

        Assert.NotEmpty(_service.GetAll());
    }

    [Fact]
    public void FoundItemGetByIdTest()
    {
        var itemOne = new FoundItemsModel
        {
            Id = 1,
            Title = "testOne",
            Category = "action",
        };
        _service.AddItem(itemOne);

        var result = _service.GetById(1);

        Assert.Equal(itemOne.Id, result.Id);
    }
}
