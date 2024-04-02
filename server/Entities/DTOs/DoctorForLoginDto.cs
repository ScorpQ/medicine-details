using Core.Entities;

namespace Entities.DTOs
{
    public class DoctorForLoginDto : IDto
    {

        public string TC { get; set; }
        public string Password { get; set; }
    }
}
