using Models.Models;

namespace DataAccess.Repository
{
    public interface IOwnerRepository
    {
        Owner? AddOwner(Owner owner);
        Owner? EditOwner(Owner owner);
        Owner? GetById(Guid id);
        void Delete(Guid id);
        bool OwnerExists(Guid ownerId);
        bool OwnerExists(string phoneNumber);
        ICollection<Owner>? GetAll();
        ICollection<Owner>? GetOwnersById(ICollection<Guid> ids);
    }
}
