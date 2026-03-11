using MiniHittegods.Domain.Models;

namespace MiniHittegods.Domain.Core;

public enum Status
{
    Available,
    Claimed,
    Returned,
    Deleted,
}

public class FoundItem
{
    public Status Status { get; private set; }

    public FoundItem()
    {
        Status = Status.Available;
    }

    public void ClaimItem()
    {
        if (Status != Status.Available)
        {
            throw new InvalidOperationException("Item can only be claimed when available.");
        }

        Status = Status.Claimed;
    }

    public void ReturnItem()
    {
        if (Status != Status.Claimed)
        {
            throw new InvalidOperationException("Item can only be returned when claimed.");
        }

        Status = Status.Returned;
    }

    public void RemoveItem()
    {
        if (Status != Status.Available)
        {
            throw new InvalidOperationException("Item can only be deleted when available.");
        }

        Status = Status.Deleted;
    }
}
