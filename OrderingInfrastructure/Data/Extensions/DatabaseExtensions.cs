using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsyc (this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDBContext context)
        {
            await SeedCustomerAsync(context);
            await SeedProductAsync(context);
            await SeedOrdersandItemsAsync(context);
        }



        private static async Task SeedCustomerAsync(ApplicationDBContext context)
        {
            if (!await context.Customers.AnyAsync())
            {
                await context.Customers.AddRangeAsync(InitialiseData.Customers);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProductAsync(ApplicationDBContext context)
        {
            if (!await context.Products.AnyAsync())
            {
                await context.Products.AddRangeAsync(InitialiseData.Products);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedOrdersandItemsAsync(ApplicationDBContext context)
        {
            if (!await context.Orders.AnyAsync())
            {
                await context.Orders.AddRangeAsync(InitialiseData.OrdersWithItems);
                await context.SaveChangesAsync();
            }
        }
    }
}
