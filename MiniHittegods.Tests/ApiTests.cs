using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.Controller;
using MiniHittegods.Api.DTO;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Services;
using Xunit;
using Controller = MiniHittegods.Api.Controller.Controller;

namespace MiniHittegods.Tests;

public class ApiTests
{
    private readonly CreateItemDto _dto = new CreateItemDto
    {
        Title = "test",
        FoundLocation = "London",
    };

    [Fact]
    public void ApiCreateItemTest()
    {
        var target = new Controller();

        var result = target.CreatItem(_dto);
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal(201, createdResult.StatusCode);

        var item = Assert.IsType<FoundItems>(createdResult.Value);
        Assert.Equal("test", item.Title);
        Assert.Equal("London", item.FoundLocation);
    }

    [Fact]
    public void ApiGetItemTest()
    {
        var target = new Controller();

        var create = target.CreatItem(_dto);
        var createdResult = Assert.IsType<CreatedResult>(create);
        var item = Assert.IsType<FoundItems>(createdResult.Value);

        var result = target.GetItem(item.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedItem = Assert.IsType<FoundItems>(okResult.Value);

        Assert.Equal(item.Id, returnedItem.Id);
        Assert.Equal("test", returnedItem.Title);
        Assert.Equal("London", returnedItem.FoundLocation);
    }
}
