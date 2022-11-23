using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.Requests
{
    public class CreatePropertyRequest
    {
        [Required]
        public string PropertyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTimeOffset RegistrationDate { get; set; }

        [Required]
        public ICollection<Owner> PropertyOwners { get; set; }
    }
}
