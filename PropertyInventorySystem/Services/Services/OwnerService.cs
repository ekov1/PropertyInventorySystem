using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services.Interfaces;

namespace Services.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner? AddOwner(Owner owner)
        {
            return this._ownerRepository.AddOwner(owner);
        }

        public Owner? EditOwner(Owner owner)
        {
            return this._ownerRepository.EditOwner(owner);
        }

        public Owner? GetById(Guid id)
        {
            return this._ownerRepository.GetById(id);
        }

        public void Delete(Guid id)
        {
            this._ownerRepository.Delete(id);
        }

        public bool OwnerExists(Guid ownerId)
        {
            return this._ownerRepository.OwnerExists(ownerId);
        }

        public bool OwnerExists(string phoneNumber)
        {
            return this._ownerRepository.OwnerExists(phoneNumber);
        }

        public ICollection<Owner>? GetAll()
        {
            return this._ownerRepository.GetAll();
        }
    }
}
