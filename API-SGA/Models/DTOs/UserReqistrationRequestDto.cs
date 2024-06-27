using System.ComponentModel.DataAnnotations;

namespace API_SGA.Models.DTOs
{
    public class UserReqistrationRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
