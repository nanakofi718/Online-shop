
namespace Catalog.Api.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid id, string Name,List< string> category, string description, string ImageFile, decimal price) 
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Product ID Required");
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Product name is required.")
                .Length(2, 150).WithMessage("Name must be between 2 to 150 characters");
            //RuleFor(x => x.category).NotEmpty();
            //RuleFor(x => x.description).MaximumLength(500);
            //RuleFor(x => x.ImageFile).MaximumLength(200);
            RuleFor(x => x.price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    internal class UpdateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand Command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(Command.id, cancellationToken);

            if(product is null)
            {
                throw new ProductNotFoundException(Command.id);
            }

            product.Name = Command.Name;
            product.Category = Command.category;
            product.Description = Command.description;
            product.ImageFile = Command.ImageFile;
            product.Price = Command.price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
