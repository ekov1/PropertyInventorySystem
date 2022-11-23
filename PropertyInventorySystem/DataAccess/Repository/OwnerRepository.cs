using DataAccess.DbContexts;
using DataAccess.Mappers;
using Models.Models;

namespace DataAccess.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Owner? AddOwner(Owner owner)
        {
            try
            {
                if (owner == null)
                {
                    throw new ArgumentNullException(nameof(owner));
                }

                var ownerEntity = owner.ToOwnerEntity();
                _context.Owners.Add(ownerEntity);
                _context.SaveChanges();

                return ownerEntity.ToOwner();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Owner? EditOwner(Owner owner)
        {
            try
            {
                if (owner == null)
                {
                    throw new ArgumentNullException(nameof(owner));
                }

                var ownerEntity = _context.Owners.Find(owner.Id);

                ownerEntity.Name = owner.Name;
                ownerEntity.Surname = owner.Surname;
                ownerEntity.PhoneNumber = owner.PhoneNumber;

                _context.Owners.Update(ownerEntity);
                _context.SaveChanges();

                return ownerEntity.ToOwner();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Owner? GetById(Guid ownerId)
        {
            try
            {
                if (ownerId == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(ownerId));
                }

                return _context.Owners.First(o => o.Id == ownerId).ToOwner();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Delete(Guid id)
        {
            var ownerEntity = _context.Owners.Find(id);

            _context.Owners.Remove(ownerEntity);
            _context.SaveChanges();
        }

        public bool OwnerExists(Guid ownerId)
        {
            if (ownerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ownerId));
            }

            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool OwnerExists(string phoneNumber)
        {
            if (phoneNumber == string.Empty)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            return _context.Owners.Any(o => o.PhoneNumber == phoneNumber);
        }

        public ICollection<Owner>? GetAll()
        {
            try
            {
                return _context.Owners.Select(x => x.ToOwner()).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ICollection<Owner>? GetOwnersById(ICollection<Guid> ids)
        {
            try
            {
                return _context.Owners.Where(x => ids.Contains(x.Id)).Select(x => x.ToOwner()).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
