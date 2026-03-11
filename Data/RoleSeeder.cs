using Microsoft.AspNetCore.Identity;

namespace AutomobileSeller.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            {
                "Admin",
                "SalesRepresentative",
                "InventoryManager",
                "ServiceAgent",
                "InsuranceCoordinator",
                "Customer"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}