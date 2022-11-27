using DataAccess.Entities;
using Models.Models;

namespace DataAccess.Mappers
{
    public static class EntityMapper
    {
        public static OwnerEntity ToOwnerEntity(this Owner owner)
        {
            return new OwnerEntity
            {
                Name = owner.Name,
                Surname = owner.Surname,
                PhoneNumber = owner.PhoneNumber
            };
        }

        public static Owner ToOwner(this OwnerEntity owner)
        {
            return new Owner
            {
                Id = owner.Id,
                Name = owner.Name,
                Surname = owner.Surname,
                PhoneNumber = owner.PhoneNumber
            };
        }

        public static PropertyEntity ToPropertyEntity(this Property property)
        {
            return new PropertyEntity
            {
                Address = property.Address,
                Price = property.Price,
                PropertyName = property.PropertyName,
                RegistrationDate = property.RegistrationDate
            };
        }

        public static Property ToProperty(this PropertyEntity propertyEntity, ICollection<Owner> owners)
        {
            return new Property
            {
                Address = propertyEntity.Address,
                Price = propertyEntity.Price,
                PropertyName = propertyEntity.PropertyName,
                PropertyOwners = owners,
                RegistrationDate = propertyEntity.RegistrationDate
            };
        }

        public static Property ToProperty(this PropertyEntity propertyEntity)
        {
            return new Property
            {
                Address = propertyEntity.Address,
                Price = propertyEntity.Price,
                PropertyName = propertyEntity.PropertyName,
                RegistrationDate = propertyEntity.RegistrationDate
            };
        }

        public static PropertyOwnerEntity ToPropertyOwnerEntity(this PropertyOwner propertyOwner)
        {
            var entity = new PropertyOwnerEntity
            {
                Owner = propertyOwner.Owner.ToOwnerEntity(),
                OwnerId = propertyOwner.Owner.Id,
                Property = propertyOwner.Property.ToPropertyEntity()
            };
            //entity.Owner.Id = propertyOwner.Owner.Id;
            return entity;
        }
    }
}
