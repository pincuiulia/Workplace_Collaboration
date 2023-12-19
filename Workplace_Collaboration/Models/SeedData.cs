using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workplace_Collaboration.Data;

namespace Workplace_Collaboration.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Roles.Any())
                {
                    return; // baza de date contine deja roluri
                }

                // CREAREA ROLURILOR IN BD
                context.Roles.AddRange(
                    new IdentityRole { Id = "ree490fef-d874-465e-8d84-09fe51bd47d0", Name = "Administrator", NormalizedName = "Administrator".ToUpper() },
                    new IdentityRole { Id = "ree490fef-d874-465e-8d84-09fe51bd47d1", Name = "Moderator", NormalizedName = "Moderator".ToUpper() },
                    new IdentityRole { Id = "ree490fef-d874-465e-8d84-09fe51bd47d2", Name = "RegisteredUser", NormalizedName = "RegisteredUser".ToUpper() },
                    new IdentityRole { Id = "ree490fef-d874-465e-8d84-09fe51bd47d3", Name = "Visitor", NormalizedName = "Visitor".ToUpper() }
                );

                var hasher = new PasswordHasher<ApplicationUser>();

                // CREAREA USERILOR IN BD
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "a88bee35-8549-4ca6-a303-638d8ffce980",
                        UserName = "admin@example.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@EXAMPLE.COM",
                        Email = "admin@example.com",
                        NormalizedUserName = "ADMIN@EXAMPLE.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },
                    new ApplicationUser
                    {
                        Id = "a88bee35-8549-4ca6-a303-638d8ffce981",
                        UserName = "moderator@example.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "MODERATOR@EXAMPLE.COM",
                        Email = "moderator@example.com",
                        NormalizedUserName = "MODERATOR@EXAMPLE.COM",
                        PasswordHash = hasher.HashPassword(null, "Moderator1!")
                    },
                    new ApplicationUser
                    {
                        Id = "a88bee35-8549-4ca6-a303-638d8ffce982",
                        UserName = "registereduser@example.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "REGISTEREDUSER@EXAMPLE.COM",
                        Email = "registereduser@example.com",
                        NormalizedUserName = "REGISTEREDUSER@EXAMPLE.COM",
                        PasswordHash = hasher.HashPassword(null, "RegisteredUser1!")
                    },
                    new ApplicationUser
                    {
                        Id = "a88bee35-8549-4ca6-a303-638d8ffce983",
                        UserName = "visitor@example.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "VISITOR@EXAMPLE.COM",
                        Email = "visitor@example.com",
                        NormalizedUserName = "VISITOR@EXAMPLE.COM",
                        PasswordHash = hasher.HashPassword(null, "Visitor1!")
                    }
                );

                // ASOCIEREA USER-ROLE
                context.UserRoles.AddRange(
                    new IdentityUserRole<string> { RoleId = "ree490fef-d874-465e-8d84-09fe51bd47d0", UserId = "a88bee35-8549-4ca6-a303-638d8ffce980" },
                    new IdentityUserRole<string> { RoleId = "ree490fef-d874-465e-8d84-09fe51bd47d1", UserId = "a88bee35-8549-4ca6-a303-638d8ffce981" },
                    new IdentityUserRole<string> { RoleId = "ree490fef-d874-465e-8d84-09fe51bd47d2", UserId = "a88bee35-8549-4ca6-a303-638d8ffce982" },
                    new IdentityUserRole<string> { RoleId = "ree490fef-d874-465e-8d84-09fe51bd47d3", UserId = "a88bee35-8549-4ca6-a303-638d8ffce983" }
                );

                context.SaveChanges();
            }
        }
    }
}
