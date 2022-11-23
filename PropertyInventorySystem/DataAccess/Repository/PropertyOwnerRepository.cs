using DataAccess.DbContexts;
using DataAccess.Entities;
using DataAccess.Mappers;
using Models.Models;
using Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Repository
{
    public class PropertyOwnerRepository : IPropertyOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyOwnerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Property AddPropertyWithOwners(Property property)
        {
            try
            {
                var ownersIds = property.PropertyOwners.Select(x => x.Id).ToList();
                var owners = _context.Owners.Where(x => ownersIds.Contains(x.Id)).ToList();
                var propertyOwners = new List<PropertyOwnerEntity>();
                var propertyEntity = property.ToPropertyEntity();
                foreach (var owner in owners)
                {
                    propertyOwners.Add(new PropertyOwnerEntity()
                    {
                        Owner = owner,
                        Property = propertyEntity
                    });
                }

                _context.PropertyOwners.AddRange(propertyOwners);
                var result = _context.SaveChanges();
                return property;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public ICollection<Property> GetByPhoneNumber(string phoneNumber)
        //{
        //    var properties =_context.Properties.Where(x=>x.PropertyOwners.Where(x=>x.Owner.PhoneNumber.StartsWith(phoneNumber)==true));
        //}

    }
}
