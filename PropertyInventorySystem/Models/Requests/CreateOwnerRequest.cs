using System.ComponentModel.DataAnnotations;

namespace Models.Requests
{
    public class CreateOwnerRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }
    }
}
