using System.Runtime.CompilerServices;
using System.Security.Claims;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Interfaces;
using MiniHittegods.Domain.Models;
using MiniHittegods.Domain.Repository;

namespace MiniHittegods.Domain.Services
{
    public class FoundItemsService
    {
        private readonly IRepository<FoundItemsModel> _repository;

        public FoundItemsService(IRepository<FoundItemsModel> repository)
        {
            _repository = repository;
        }

        public bool AddItem(FoundItemsModel item)
        {
            if (item == null)
            {
                return false;
            }

            item.Status = Status.Available;

            _repository!.Add(item);
            _repository.SaveChanges();

            return true;
        }

        public bool RemoveItem(FoundItemsModel item)
        {
            var existingItem = _repository!.GetById(item.Id);

            if (existingItem == null)
            {
                return false;
            }
            _repository.Remove(item);
            _repository.SaveChanges();
            return true;
        }

        public bool ClaimItem(FoundItemsModel item, string? claimedBy)
        {
            var existingItem = _repository!.GetById(item.Id);

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
            _repository.SaveChanges();
            return true;
        }

        public bool ReturnItem(FoundItemsModel item)
        {
            var existingItem = _repository!.GetById(item.Id);

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
            _repository.SaveChanges();
            return true;
        }

        public List<FoundItemsModel> GetAllItem()
        {
            return _repository!.GetAll().ToList();
        }

        public FoundItemsModel GetById(int id)
        {
            return _repository!.GetById(id);
        }
    }
}
