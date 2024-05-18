
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler(IDocumentSession documentSession) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
  public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
  {
     var products = await documentSession.Query<Product>().Where(p => p.Category.Contains(query.category)).ToListAsync();
    return new GetProductByCategoryResult(products);
  }
}