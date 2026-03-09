using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;

namespace MiniHittegods.Domain.Services;

public static class FoundItemsService
{
    public static readonly Repository<FoundItems> _repository = new Repository<FoundItems>();

    public static bool AddItem(FoundItems item)
    {
        if (item == null)
        {
            return false;
        }

        var existingItem = _repository.GetById(item.Id);

        if (existingItem != null)
        {
            return false;
        }

        _repository.Add(item);
        return true;
    }

    public static void RemoveItem(FoundItems item)
    {
        _repository.Remove(item);
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
