using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.DTO;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Services;

namespace MiniHittegods.Api.Controller;

[ApiController]
public class Controller : ControllerBase
{
    [HttpPost]
    [Route("api/items")]
    public IActionResult CreatItem(CreateItemDto dto)
    {
        var item = new FoundItems
        {
            Title = dto.Title,
            FoundLocation = dto.FoundLocation,
            ItemStatus = ItemStatus.Available.ToString(),
            FoundAtUtc = DateTime.UtcNow.ToString("o"),
        };

        var result = FoundItemsService.AddItem(item);

        if (!result)
        {
            return Conflict();
        }
        return Created();
    }

    [HttpGet]
    [Route("api/items/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new[] { "Sample data" });
    }

    [HttpDelete]
    [Route("api/items/{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(new[] { "Sample data" });
    }
}
