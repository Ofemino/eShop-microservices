using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using (var session = store.LightweightSession())
        {
            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            session.Store<Product>(GetPreconfiguredProduct());
            await session.SaveChangesAsync(cancellation);
        }
    }

    private IEnumerable<Product> GetPreconfiguredProduct() =>
        new List<Product>
        {
            new Product
            {
                Id = new Guid("f88e83b3-3b29-4288-8f3b-2ef4270c69df"),
                Name = "IPhone X",
                Description = "This is an i-phone",
                ImageFile = "",
                Category = new List<string>{"Smart Phone"},
                Price = 950.00M
            },
            new Product
            {
                Id = new Guid("118330ed-1ac8-435d-987a-88f6145f90dd"),
                Name = "IPhone 11",
                Description = "This is an i-phone",
                ImageFile = "",
                Category = new List<string>{"Smart Phone"},
                Price = 900.50M
            },
            new Product
            {
                Id = new Guid("a810e79f-de5e-47ca-ba74-b572aebb2ad4"),
                Name = "Samsung 9",
                Description = "This is an Samsung",
                ImageFile = "",
                Category = new List<string>{"Smart Phone"},
                Price = 900.50M
            },
            new Product
            {
                Id = new Guid("03c64c48-a41b-4822-bb42-0e6defb343c1"),
                Name = "Book",
                Description = "This is an book",
                ImageFile = "",
                Category = new List<string>{"Online Bool"},
                Price = 10.50M
            },
        };
}