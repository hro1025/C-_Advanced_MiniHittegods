using System.Runtime.InteropServices;
using System.Security.Claims;
using Microsoft.VisualBasic;
using MiniHittegods.Domain.Models;

namespace MiniHittegods.Domain.Core;

public enum ItemStatus
{
    Available,
    Claimed,
    Returned,

    Deleted,
}

public class FoundItem : Model
{
    public new ItemStatus Status { get; private set; }

    public FoundItem()
    {
        Status = ItemStatus.Available;
    }

    public void Claim()
    {
        if (Status != ItemStatus.Available)
        {
            throw new InvalidOperationException("Item can only be claimed when available.");
        }
        else
        {
            Status = ItemStatus.Claimed;
        }
    }

    public void Return()
    {
        if (Status != ItemStatus.Claimed)
        {
            throw new InvalidOperationException("Item can only be returned when claimed.");
        }
        else
        {
            Status = ItemStatus.Returned;
        }
    }

    public void Delete()
    {
        if (Status != ItemStatus.Available)
        {
            throw new InvalidOperationException("Item can only be deleted when available.");
        }
        else
        {
            Status = ItemStatus.Deleted;
        }
    }
}
