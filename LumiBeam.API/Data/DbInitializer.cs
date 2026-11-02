using LumiBeam.API.Services.Interfaces;
using LumiBeam.Domain.Entities;
using LumiBeam.Domain.Enums;
using LumiBeam.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LumiBeam.API.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LumiBeamDbContext>();
            var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasherService>();

            // Перевіряємо та створюємо початкового адміністратора
            if (!await context.Users.AnyAsync())
            {
                var admin = new User
                {
                    FullName = "Головний Адміністратор",
                    PhoneNumber = "+380670000001",
                    PasswordHash = passwordHasher.HashPassword("AdminPass2026!"),
                    Role = UserRole.Administrator,
                    StoreLocation = "Центральний салон LumiBean (Київ)"
                };

                var seller = new User
                {
                    FullName = "Олександр Продавець",
                    PhoneNumber = "+380671112233",
                    PasswordHash = passwordHasher.HashPassword("SellerPass2026!"),
                    Role = UserRole.Seller,
                    StoreLocation = "Центральний салон LumiBean (Київ)"
                };

                await context.Users.AddRangeAsync(admin, seller);
            }

            // Перевіряємо та створюємо початкові категорії та товари
            if (!await context.Categories.AnyAsync())
            {
                var trackCategory = new Category
                {
                    Name = "Трекові системи",
                    Description = "Магнітні та однофазні трекові світильники і шинопроводи"
                };

                var ledStripCategory = new Category
                {
                    Name = "LED-стрічки та комплектуючі",
                    Description = "Стрічки 12V/24V, блоки живлення, алюмінієві профілі"
                };

                await context.Categories.AddRangeAsync(trackCategory, ledStripCategory);
                await context.SaveChangesAsync();

                var products = new List<Product>
            {
                new()
                {
                    Name = "Світильник магнітний трековий 20W 4000K",
                    SKU = "MAG-TRK-20W",
                    Barcode = "4820000010014",
                    RetailPrice = 1450.00m,
                    BonusPerUnit = 60.00m,
                    Category = trackCategory
                },
                new()
                {
                    Name = "LED-стрічка SMD 2835 120 led/m 24V Warm White",
                    SKU = "LED-2835-24V-WW",
                    Barcode = "4820000010021",
                    RetailPrice = 180.00m,
                    BonusPerUnit = 8.50m,
                    Category = ledStripCategory
                }
            };

                await context.Products.AddRangeAsync(products);
            }

            await context.SaveChangesAsync();
        }
    }
}
