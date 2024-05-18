namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");
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