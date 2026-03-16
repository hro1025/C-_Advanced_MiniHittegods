using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using MiniHittegods.Api.DTO;
using MiniHittegods.Domain;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Services;

namespace MiniHittegods.Api.Controller;

[ApiController]
public class ApiController : ControllerBase
{
    private readonly FoundItemsService _service;

    public ApiController(FoundItemsService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("api/items/createitem")]
    public IActionResult CreatItem(CreateItemDto dto)
    {
        var item = new FoundItemsModel
        {
            Title = dto.Title,
            FoundLocation = dto.FoundLocation,
            Category = dto.Category,
            Status = Status.Available,
            FoundAtUtc = DateTime.UtcNow.ToString(),
        };

        var result = _service.AddItem(item);

        if (!result)
        {
            return Conflict();
        }
        return Created($"/api/items/{item.Id}", item);
    }

    [HttpGet]
    [Route("api/items/getallitems")]
    public IActionResult GetAllItems(string? status, string? category, string? item)
    {
        var allItems = _service.GetAllItem();

        if (!string.IsNullOrEmpty(status))
        {
            allItems = allItems.Where(i => i.Status.ToString() == status).ToList();
        }
        if (!string.IsNullOrEmpty(category))
        {
            allItems = allItems.Where(i => i.Category == category).ToList();
        }

        if (!string.IsNullOrEmpty(item))
        {
            allItems = allItems
                .Where(i =>
                    i.Title != null && i.Title.Contains(item, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }
        return Ok(allItems);
    }

    [HttpGet]
    [Route("api/items/{id}/getitem")]
    public IActionResult GetItem(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    [Route("api/items/{id}/claim")]
    public IActionResult Claim(int id, string? claimedBy)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }
        var result = _service.ClaimItem(item, claimedBy);

        if (!result)
        {
            return Conflict();
        }
        return Ok(item);
    }

    [HttpPost]
    [Route("api/items/{id}/return")]
    public IActionResult Return(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }
        if (item.Status != Status.Claimed)
        {
            return Conflict();
        }
        _service.ReturnItem(item);
        return Ok(item);
    }

    [HttpDelete]
    [Route("api/items/{id}/remove")]
    public IActionResult Remove(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        if (item.Status == Status.Available)
        {
            _service.RemoveItem(item);
            return NoContent();
        }

        return Conflict();
    }
}
