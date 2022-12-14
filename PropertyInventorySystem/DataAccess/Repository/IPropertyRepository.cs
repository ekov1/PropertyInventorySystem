using Models.Models;

namespace DataAccess.Repository
{
    public interface IPropertyRepository
    {
        Property? GetById(Guid id);
        void Delete(Guid id);
        bool PropertyExists(Guid id);
        Property AddPropertyWithOwners(Property property);
        ICollection<Property> GetByPhoneNumber(string phoneNumber);
    }
}
