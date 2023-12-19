using Microsoft.AspNetCore.Identity;

namespace Workplace_Collaboration.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; internal set; }
        public string UserName { get; internal set; }
        public bool EmailConfirmed { get; internal set; }
        public string NormalizedEmail { get; internal set; }
        public string Email { get; internal set; }
        public string NormalizedUserName { get; internal set; }
        public string PasswordHash { get; internal set; }
    }
}
