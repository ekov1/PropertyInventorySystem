using Models.Models;
using Models.Requests;
using Swashbuckle.AspNetCore.Filters;


namespace API.Examples
{
    public class CreatePropertyRequestExample : IExamplesProvider<CreatePropertyRequest>
    {
        public CreatePropertyRequest GetExamples()
        {
            return new CreatePropertyRequest()
            {
                Address = "adress 1",
                Price = 100,
                PropertyName = "Mirador de Monte Pinar",
                PropertyOwners = new[] {
                    new Owner {
                        Id = Guid.NewGuid(),
                        Name = "Antonio",
                        Surname ="Recio",
                        PhoneNumber= "123"
                    }
                }
            };
        }
    }
}
