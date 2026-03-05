using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;

namespace MiniHittegods.Domain.Services;

public static class FoundItemsService
{
    public static readonly Repository<FoundItems> _repository = new Repository<FoundItems>();

    public static void AddItem(FoundItems item)
    {
        _repository.Add(item);
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
