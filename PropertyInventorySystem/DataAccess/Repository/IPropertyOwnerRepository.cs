using Models.Models;

namespace DataAccess.Repository
{
    public interface IPropertyOwnerRepository
    {
        Property AddPropertyWithOwners(Property property);
    }
}
