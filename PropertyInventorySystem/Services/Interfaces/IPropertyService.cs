using Models.Models;
namespace Services.Interfaces
{
    public interface IPropertyService
    {
        Property CreateProperty(Property property);
        void Delete(Guid id);
        bool PropertyExists(Guid id);
        ICollection<Property> GetByPhoneNumber(string phoneNumber);
    }
}
