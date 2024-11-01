using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Medicine.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public byte[] ProfilePicture { get; set; } = null;
    }
}
