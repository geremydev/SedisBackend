using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class AssistantUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser assistantUser = new();
            assistantUser.UserName = "assistantuser";
            assistantUser.Email = "assistantuser@email.com";
            assistantUser.PhoneNumber = "829-123-9811";
            assistantUser.IsActive = true;
            assistantUser.EmailConfirmed = true;
            assistantUser.PhoneNumberConfirmed = true;
            assistantUser.ImageUrl = ".";

            if (userManager.Users.All(u => u.Id != assistantUser.Id))
            {
                var user = await userManager.FindByEmailAsync(assistantUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(assistantUser, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(assistantUser, RolesEnum.Assistant.ToString());
                }
            }
        }
    }
}
