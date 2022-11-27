using DataAccess.Repository;
using Models.Models;
using Services.Interfaces;

namespace Services.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService( IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Property CreateProperty(Property property)
        {
            return _propertyRepository.AddPropertyWithOwners(property);
        }

        public void Delete(Guid id)
        {
           this._propertyRepository.Delete(id);
        }

        public ICollection<Property> GetByPhoneNumber(string phoneNumber)
        {
            return this._propertyRepository.GetByPhoneNumber(phoneNumber);
        }

        public bool PropertyExists(Guid id)
        {
           return this._propertyRepository.PropertyExists(id);
        }
    }
}
