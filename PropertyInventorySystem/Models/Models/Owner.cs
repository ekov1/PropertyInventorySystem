using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Owner
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
