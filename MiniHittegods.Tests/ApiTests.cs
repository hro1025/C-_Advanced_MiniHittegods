using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.Controller;
using MiniHittegods.Api.DTO;
using Xunit;
using Controller = MiniHittegods.Api.Controller.Controller;

namespace MiniHittegods.Tests;

public class ApiTest
{
    private CreateItemDto dto = new CreateItemDto { Title = "test", FoundLocation = "London" };

    [Fact]
    public void ApiCreateItem()
    {
        var target = new Controller();

        var result = target.CreatItem(dto);

        Assert.IsType<CreatedResult>(result);
    }
}
