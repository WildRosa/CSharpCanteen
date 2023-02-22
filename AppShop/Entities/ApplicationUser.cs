using Microsoft.AspNetCore.Identity;

namespace AppShop.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] AvatarImage { get; set; } 
    }
}
