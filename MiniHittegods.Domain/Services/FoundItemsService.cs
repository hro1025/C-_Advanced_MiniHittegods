using System.Runtime.CompilerServices;
using System.Security.Claims;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Interfaces;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;

namespace MiniHittegods.Domain.Services
{
    public static class FoundItemsService
    {
        public static readonly Repository<FoundItemsModel> _repository =
            new Repository<FoundItemsModel>();
        private static int _nextId = 1;

        public static bool AddItem(FoundItemsModel item)
        {
            if (item == null)
            {
                return false;
            }

            item.Id = _nextId++;
            item.Status = Status.Available;

            _repository.Add(item);

            return true;
        }

        public static bool RemoveItem(FoundItemsModel item)
        {
            var existingItem = _repository.GetById(item.Id);

            if (existingItem == null)
            {
                return false;
            }
            _repository.Remove(item);
            return true;
        }

        public static bool ClaimItem(FoundItemsModel item, string? claimedBy)
        {
            var existingItem = _repository.GetById(item.Id);

            if (existingItem == null)
            {
                return false;
            }
            if (existingItem.Status != Status.Available)
            {
                return false;
            }
            existingItem.Status = Status.Claimed;
            existingItem.ClaimedBy = claimedBy;
            existingItem.ClaimedAtUtc = DateTime.UtcNow.ToString();
            return true;
        }

        public static bool ReturnItem(FoundItemsModel item)
        {
            var existingItem = _repository.GetById(item.Id);

            if (existingItem == null)
            {
                return false;
            }
            if (existingItem.Status != Status.Claimed)
            {
                return false;
            }
            existingItem.Status = Status.Available;
            existingItem.ReturnedAtUtc = DateTime.UtcNow.ToString();
            return true;
        }

        public static List<FoundItemsModel> GetAllItem()
        {
            return _repository.GetAll().ToList();
        }

        public static FoundItemsModel GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
