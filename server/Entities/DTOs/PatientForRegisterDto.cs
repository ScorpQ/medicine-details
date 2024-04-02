using Core.Entities;

namespace Entities.DTOs
{
    public class PatientForRegisterDto : IDto
    {
       
        public string TC { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
