using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<StoreContext>()
              ?? throw new InvalidOperationException("StoreContext is null.");
            var userManager = services.GetRequiredService<UserManager<User>>()
            ?? throw new InvalidOperationException("Failed to retrieve UserManager");
            await SeedData(context, userManager);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }

    private static async Task SeedData(StoreContext context, UserManager<User> userManager)
    {
        context.Database.Migrate();
        if (!userManager.Users.Any())
        {
            var user = new User
            {
                UserName = "bob@test.com",
                Email = "bob@test.com"
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "Member");

            var admin = new User
            {
                UserName = "admin@test.com",
                Email = "admin@test.com"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, ["Member", "Admin"]);
        }
        if (context.Products.Any()) return;
        var products = new List<Product>
    {
          new() {
                    Name = "Angular 17 From Scratch",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/Angular/angular1.png",
                    Brand = "Angular",
                    Type = "Framework",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Step-By-Step Angular",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    PictureUrl = "/images/Angular/angular2.jpeg",
                    Brand = "Angular",
                    Type = "Framework",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Asp.net Black Book",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/dotnet/dotnet2.jpeg",
                    Brand = "NetCore",
                    Type = "Framework",
                    QuantityInStock = 100
                },
                new() {
                    Name = "the little Asp.net Core book",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    PictureUrl = "/images/dotnet/dotnet3.jpeg",
                    Brand = "NetCore",
                    Type = "Framework",
                    QuantityInStock = 100
                },
                new() {
                    Name = "REACT",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    PictureUrl = "/images/React/react1.jpeg",
                    Brand = "React",
                    Type = "UI",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Typescript Basic",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 12000,
                    PictureUrl = "/images/Typescript/typescript1.png",
                    Brand = "TypeScript",
                    Type = "Programming Language",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Modern TypeScript",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1000,
                    PictureUrl = "/images/Typescript/typescript2.png",
                    Brand = "TypeScript",
                    Type = "Programming Language",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Essential TypeScript",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1000,
                    PictureUrl = "/images/Typescript/typescript3.png",
                    Brand = "TypeScript",
                    Type = "Programming Language",
                    QuantityInStock = 100
                },
                new() {
                    Name = "Visual Studio Code Free Download",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    PictureUrl = "/images/VSCode/vscode1.png",
                    Brand = "VS Code",
                    Type = "Editor",
                    QuantityInStock = 100
                },
                 new() {
                    Name = "VS Code AI",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    PictureUrl = "/images/VSCode/vscode3.png",
                    Brand = "VS Code",
                    Type = "Editor",
                    QuantityInStock = 100
                },
                //new() {
                //    Name = "Purple React Woolen Hat",
                //    Description =
                //        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 1500,
                //    PictureUrl = "/images/products/hat-react2.png",
                //    Brand = "React",
                //    Type = "Hats",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Blue Code Gloves",
                //    Description =
                //        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 1800,
                //    PictureUrl = "/images/products/glove-code1.png",
                //    Brand = "VS Code",
                //    Type = "Gloves",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Green Code Gloves",
                //    Description =
                //        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 1500,
                //    PictureUrl = "/images/products/glove-code2.png",
                //    Brand = "VS Code",
                //    Type = "Gloves",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Purple React Gloves",
                //    Description =
                //        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 1600,
                //    PictureUrl = "/images/products/glove-react1.png",
                //    Brand = "React",
                //    Type = "Gloves",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Green React Gloves",
                //    Description =
                //        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 1400,
                //    PictureUrl = "/images/products/glove-react2.png",
                //    Brand = "React",
                //    Type = "Gloves",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Redis Red Boots",
                //    Description =
                //        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                //    Price = 25000,
                //    PictureUrl = "/images/products/boot-redis1.png",
                //    Brand = "Redis",
                //    Type = "Boots",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Core Red Boots",
                //    Description =
                //        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                //    Price = 18999,
                //    PictureUrl = "/images/products/boot-core2.png",
                //    Brand = "NetCore",
                //    Type = "Boots",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Core Purple Boots",
                //    Description =
                //        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                //    Price = 19999,
                //    PictureUrl = "/images/products/boot-core1.png",
                //    Brand = "NetCore",
                //    Type = "Boots",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Angular Purple Boots",
                //    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                //    Price = 15000,
                //    PictureUrl = "/images/products/boot-ang2.png",
                //    Brand = "Angular",
                //    Type = "Boots",
                //    QuantityInStock = 100
                //},
                //new() {
                //    Name = "Angular Blue Boots",
                //    Description =
                //        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                //    Price = 18000,
                //    PictureUrl = "/images/products/boot-ang1.png",
                //    Brand = "Angular",
                //    Type = "Boots",
                //    QuantityInStock = 100
                //},
    };
        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
