using System;
using BeerFinder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BeerFinder
{
    public class Initializer
    {
        public static async void Initialize(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _manager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                
                IdentityRole role=new IdentityRole("admin");
                await _roleManager.CreateAsync(role);

                var user = new ApplicationUser()
                {
                    UserName = "hrvoje.maligec@fer.hr",
                    Email = "hrvoje.maligec@fer.hr",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                IdentityResult check = await _manager.CreateAsync(user, "$ifrA123");
                if (check.Succeeded)
                {
                    await _manager.AddToRoleAsync(user, "admin");
                }
            }
        }
    }
}
