using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
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
            ItemStatus = Status.Available.ToString(),
            FoundAtUtc = DateTime.UtcNow.ToString("o"),
        };

        var result = FoundItemsService.AddItem(item);

        if (!result)
        {
            return Conflict();
        }
        return Created($"/api/items/{item.Id}", item);
    }

    [HttpGet]
    [Route("api/items/{id}")]
    public IActionResult Get(int id)
    {
        var item = FoundItemsService.GetByIdItem(id);

        if (item == null)
        {
            return NotFound();
        }
        return Ok($"/api/items/{item}");
    }

    [HttpPost]
    [Route("api/items/{id}/claim")]
    public IActionResult Claim(int id)
    {
        var result = FoundItemsService.ClaimItem(id);

        if (!result)
        {
            return Conflict();
        }
        return Ok($"/api/items/claim{result}");
    }

    [HttpDelete]
    [Route("api/items/{id}")]
    public IActionResult Remove(int id)
    {
        var item = FoundItemsService.GetByIdItem(id);

        if (item != null)
        {
            return NotFound();
        }
        return Ok();
    }
}
