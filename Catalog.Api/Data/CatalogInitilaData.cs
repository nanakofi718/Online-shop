using Marten.Schema;

namespace Catalog.Api.Data
{
    public class CatalogInitilaData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync(cancellation))
                return;

            session.Store<Product>(GetPreconfiguredProducts());

            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "iPhone X",
                Description = "Apple smartphone with Face ID and OLED display",
                ImageFile = "iphone-x.png",
                Price = 4500,
                Category = new List<string> { "Smartphones", "Electronics" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S22",
                Description = "Samsung flagship Android smartphone",
                ImageFile = "samsung-s22.png",
                Price = 4200,
                Category = new List<string> { "Smartphones", "Electronics" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 13",
                Description = "Ultra-thin laptop for developers and designers",
                ImageFile = "dell-xps13.png",
                Price = 9800,
                Category = new List<string> { "Laptops", "Computers" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple AirPods Pro",
                Description = "Noise cancelling wireless earbuds",
                ImageFile = "airpods-pro.png",
                Price = 1800,
                Category = new List<string> { "Audio", "Accessories" }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sony WH-1000XM5",
                Description = "Premium noise cancelling headphones",
                ImageFile = "sony-wh1000xm5.png",
                Price = 2500,
                Category = new List<string> { "Audio", "Accessories" }
            }
        };
    }
}
