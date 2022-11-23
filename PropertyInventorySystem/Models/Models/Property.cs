namespace Models.Models
{
    public class Property
    {
        public Guid Id { get; set; }

        public string PropertyName { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public ICollection<Owner> PropertyOwners { get; set; }
    }
}
