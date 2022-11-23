using DataAccess.DbContexts;
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

       
    }
}
