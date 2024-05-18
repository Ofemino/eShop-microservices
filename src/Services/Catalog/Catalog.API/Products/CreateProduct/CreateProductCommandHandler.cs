namespace Catalog.API.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession documentSession)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //create product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Category = command.Category,
            Price = command.Price
        };

        //save product entity to database
        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);
        //return the CreateProductResult object
        return new CreateProductResult(product.Id);
    }
}