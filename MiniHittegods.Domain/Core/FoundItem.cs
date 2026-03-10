using MiniHittegods.Domain.Models;

namespace MiniHittegods.Domain.Core;

public enum ItemStatus
{
    Available,
    Claimed,
    Returned,
    Deleted,
}

public class FoundItem
{
    public ItemStatus Status { get; private set; }

    public FoundItem()
    {
        Status = ItemStatus.Available;
    }

    public void ClaimItem(int id)
    {
        if (Status != ItemStatus.Available)
        {
            throw new InvalidOperationException("Item can only be claimed when available.");
        }

        Status = ItemStatus.Claimed;
    }

    public void ReturnItem()
    {
        if (Status != ItemStatus.Claimed)
        {
            throw new InvalidOperationException("Item can only be returned when claimed.");
        }

        Status = ItemStatus.Returned;
    }

    public void RemoveItem()
    {
        if (Status != ItemStatus.Available)
        {
            throw new InvalidOperationException("Item can only be deleted when available.");
        }

        Status = ItemStatus.Deleted;
    }
}
