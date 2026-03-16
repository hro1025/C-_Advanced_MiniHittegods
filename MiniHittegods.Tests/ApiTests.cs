using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.Controller;
using MiniHittegods.Api.DTO;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;
using MiniHittegods.Domain.Services;
using Xunit;

namespace MiniHittegods.Tests;

public class ApiTests
{
    private readonly Repository<FoundItemsModel> _repository;
    private readonly FoundItemsService _service;
    private readonly ApiController _controller;
    private readonly CreateItemDto _dto = new CreateItemDto
    {
        Title = "test",
        FoundLocation = "London",
    };

    public ApiTests()
    {
        _repository = new Repository<FoundItemsModel>();
        _service = new FoundItemsService(_repository);
        _controller = new ApiController(_service);
    }

    [Fact]
    public void CreateItemTest102()
    {
        var createItem = _controller.CreatItem(_dto);
        var createResult = Assert.IsType<CreatedResult>(createItem);
        Assert.Equal(201, createResult.StatusCode);
    }

    [Fact]
    public void GetAllItemTest()
    {
        _controller.CreatItem(_dto);
        var getAllItems = _controller.GetAllItems(null, null, null);

        var result = Assert.IsType<OkObjectResult>(getAllItems);
        var items = Assert.IsAssignableFrom<IEnumerable<FoundItemsModel>>(result.Value);

        Assert.NotEmpty(items);
    }

    [Fact]
    public void GetItemTest200()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        var result = Assert.IsType<OkObjectResult>(_controller.GetItem(id));
        var item = Assert.IsType<FoundItemsModel>(result.Value);

        Assert.Equal(id, item.Id);
    }

    [Fact]
    public void GetItemTest404()
    {
        var result = Assert.IsType<NotFoundResult>(_controller.GetItem(999));

        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void ClaimItemTest200()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        var result = Assert.IsType<OkObjectResult>(_controller.Claim(id, null));

        var item = Assert.IsType<FoundItemsModel>(result.Value);

        Assert.Equal("Claimed", item.Status.ToString());
    }

    [Fact]
    public void ClaimItemTest404()
    {
        var result = Assert.IsType<NotFoundResult>(_controller.Claim(777, null));

        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void ClaimItemTest409()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        _controller.Claim(id, null);
        var result = _controller.Claim(id, null);

        var item = Assert.IsType<ConflictResult>(result);
        Assert.Equal(409, item.StatusCode);
    }

    [Fact]
    public void ReturnItemTest200()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        var claimItem = Assert.IsType<OkObjectResult>(_controller.Claim(id, null));
        Assert.IsType<OkObjectResult>(claimItem);

        var result = Assert.IsType<OkObjectResult>(_controller.Return(id));
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void ReturnItemTest404()
    {
        var result = Assert.IsType<NotFoundResult>(_controller.Return(999));

        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void ReturnItemTest409()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        var result = Assert.IsType<ConflictResult>(_controller.Return(id));
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public void RemoveItemTest204()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        var result = _controller.Remove(id);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void RemoveItemTest404()
    {
        var result = Assert.IsType<NotFoundResult>(_controller.Remove(999));

        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void RemoveItemTest409()
    {
        var createItem = _controller.CreatItem(_dto);
        var createdResult = (CreatedResult)createItem;
        var id = ((FoundItemsModel)createdResult.Value!).Id;

        _controller.Claim(id, null);
        var result = _controller.Remove(id);
        Assert.IsType<ConflictResult>(result);
    }
}
