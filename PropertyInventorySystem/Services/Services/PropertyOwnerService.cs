using DataAccess.Repository;
using Models.Models;
using Models.Requests;
using Services.Interfaces;

namespace Services.Services
{
    public class PropertyOwnerService : IPropertyOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;

        public PropertyOwnerService(IOwnerRepository ownerRepository, IPropertyOwnerRepository propertyOwnerRepository)
        {
            _ownerRepository = ownerRepository;
            _propertyOwnerRepository = propertyOwnerRepository;
        }

        public Property CreateProperty(Property property)
        {
            return _propertyOwnerRepository.AddPropertyWithOwners(property);
        }
    }
}
