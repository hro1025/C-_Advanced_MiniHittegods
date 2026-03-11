using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.Controller;
using MiniHittegods.Api.DTO;
using MiniHittegods.Domain.Models;
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
    public void ApiCreateItem()
    {
        var target = new Controller();

        var result = target.CreatItem(_dto);
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal(201, createdResult.StatusCode);

        var item = Assert.IsType<FoundItems>(createdResult.Value);
        Assert.Equal("test", item.Title);
        Assert.Equal("London", item.FoundLocation);
    }
}
