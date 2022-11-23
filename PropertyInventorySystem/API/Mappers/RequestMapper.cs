using Models.Models;
using Models.Requests;

namespace API.Mappers
{
    public static class RequestMapper
    {
        public static Owner ToOwner(this CreateOwnerRequest ownerRequest)
        {
            return new Owner
            {
                Name = ownerRequest.Name,
                Surname = ownerRequest.Surname,
                PhoneNumber = ownerRequest.PhoneNumber
            };
        }

        public static Owner ToOwner(this EditOwnerRequest editOwnerRequest)
        {
            return new Owner
            {
                Id = editOwnerRequest.Id,
                Name = editOwnerRequest.Name,
                Surname = editOwnerRequest.Surname,
                PhoneNumber = editOwnerRequest.PhoneNumber
            };
        }

        public static Property ToProperty(this CreatePropertyRequest createPropertyRequest)
        {
            return new Property
            {
                Address = createPropertyRequest.Address,
                Price = createPropertyRequest.Price,
                PropertyName = createPropertyRequest.PropertyName,
                PropertyOwners = createPropertyRequest.PropertyOwners,
                RegistrationDate = createPropertyRequest.RegistrationDate
            };
        }
    }
}
