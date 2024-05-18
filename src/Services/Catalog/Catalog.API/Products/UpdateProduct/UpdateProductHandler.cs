namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession documentSession)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await documentSession.LoadAsync<Product>(command.Id, cancellationToken);
        if (product is null) throw new ProductNotFoundException(command.Id);

        product.Category = command.Category;
        product.Name = command.Name;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        documentSession.Update(product);
        await documentSession.SaveChangesAsync(cancellationToken);
        return new UpdateProductResult(true);
    }
}