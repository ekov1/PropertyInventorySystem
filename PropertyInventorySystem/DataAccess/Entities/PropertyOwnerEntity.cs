namespace DataAccess.Entities
{
    public class PropertyOwnerEntity
    {
        public Guid OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
        public Guid PropertyId { get; set; }
        public PropertyEntity Property { get; set; }
    }
}
