namespace Catalog.API.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        RuleFor(x=>x.ImageFile)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        RuleFor(x=>x.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

    }
}