using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Interfaces;

namespace MiniHittegods.Domain.Models;

public class FoundItems : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? FoundLocation { get; set; }

    public string? FoundAtUtc { get; set; }

    public string? ItemStatus { get; set; }

    public string? ClaimedBy { get; set; }

    public string? ClaimedAtUtc { get; set; }

    public string? ReturnedAtUtc { get; set; }
}
