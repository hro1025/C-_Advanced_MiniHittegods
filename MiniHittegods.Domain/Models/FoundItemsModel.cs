using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.interfaces;

namespace MiniHittegods.Domain.Models;

public class FoundItemsModel : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? FoundLocation { get; set; }

    public string? FoundAtUtc { get; set; }

    public string? ClaimedBy { get; set; }

    public string? ClaimedAtUtc { get; set; }

    public string? ReturnedAtUtc { get; set; }
    public Status Status { get; set; }
}
