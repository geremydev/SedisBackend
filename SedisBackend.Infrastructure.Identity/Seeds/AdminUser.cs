﻿using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class AdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser adminuser = new();
            adminuser.UserName = "adminuser";
            adminuser.Email = "adminuser@email.com";
            adminuser.PhoneNumber = "829-123-9811";
            adminuser.EmailConfirmed = true;
            adminuser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != adminuser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminuser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(adminuser, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(adminuser, RolesEnum.Admin.ToString());
                }
            }
        }
    }
}
