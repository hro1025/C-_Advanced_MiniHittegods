using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;

namespace MiniHittegods.Domain.Services;

public static class FoundItemsService
{
    public static readonly Repository<FoundItems> _repository = new Repository<FoundItems>();

    public static bool AddItem(FoundItems item)
    {
        item.Id = _repository.GetAll().Count() + 1;

        var existingItem = _repository.GetById(item.Id);

        if (existingItem != null)
        {
            return false;
        }

        _repository.Add(item);
        return true;
    }

    public static bool RemoveItem(FoundItems item)
    {
        var existingItem = _repository.GetById(item.Id);

        if (existingItem == null)
        {
            return false;
        }
        _repository.Remove(item);
        return true;
    }

    public static bool ClaimItem(FoundItems item)
    {
        var existingItem = _repository.GetById(item.Id);

        if (existingItem == null)
        {
            return false;
        }
        if (existingItem.Status != ItemStatus.Available)
        {
            return false;
        }
        item.Status = ItemStatus.Claimed;
        return true;
    }

    public static void GetAllItem()
    {
        _repository.GetAll();
    }

    public static FoundItems GetByIdItem(int id)
    {
        return _repository.GetById(id);
    }
}
