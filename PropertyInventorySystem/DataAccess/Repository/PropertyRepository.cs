using DataAccess.DbContexts;
using DataAccess.Entities;
using DataAccess.Mappers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Models;
using Property = Models.Models.Property;

namespace DataAccess.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Property? GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var ownerIds = _context.PropertyOwners.Where(x=>x.PropertyId== id).Select(x=>x.OwnerId);
                var owners = _context.Owners.Where(x => ownerIds.Contains(x.Id)).Select(x => x.ToOwner()).ToList();
                return _context.Properties.First(o => o.Id == id).ToProperty(owners);
            }
            catch (Exception)
            {
                return null;
            }
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

        public ICollection<Property> GetByPhoneNumber(string phoneNumber)
        {
            var owners = _context.Owners.Where(x => x.PhoneNumber.StartsWith(phoneNumber)).Select(x => x.Id).ToList();
            var propIds = _context.PropertyOwners.Where(x => owners.Contains(x.OwnerId)).Select(x => x.PropertyId).ToList();
            var properties = _context.Properties.Where(x => propIds.Contains(x.Id)).Select(x => x.ToProperty()).ToList();
            return properties;
        }

        public void Delete(Guid id)
        {
            var propertyEntity = _context.Properties.Find(id);

            _context.Properties.Remove(propertyEntity);
            _context.SaveChanges();
        }

        public bool PropertyExists(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                return _context.Properties.Any(o => o.Id == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
