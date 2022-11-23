using Models.Models;
using Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace API.Examples
{
    public class CreateOwnerRequestExample : IExamplesProvider<CreateOwnerRequest>
    {
        public CreateOwnerRequest GetExamples()
        {
            return new CreateOwnerRequest()
            {
                Name = "Enrique",
                Surname = "Pastor",
                PhoneNumber = "123"
            };
        }
    }
}
