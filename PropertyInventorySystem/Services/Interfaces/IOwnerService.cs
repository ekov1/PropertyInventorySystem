using Models.Models;

namespace Services.Interfaces
{
    public interface IOwnerService
    {
        Owner? AddOwner(Owner owner);
        Owner? EditOwner(Owner owner);
        Owner? GetById(Guid id);
        void Delete(Guid id);
        bool OwnerExists(Guid ownerId);
        bool OwnerExists(string phoneNumber);
        ICollection<Owner>? GetAll();
    }
}
