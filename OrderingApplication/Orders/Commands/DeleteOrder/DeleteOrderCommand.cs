namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid OrderId) 
    : ICommand<DeleteOrderResults>;

public record DeleteOrderResults (bool IsSuccess);

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand> 
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is Required");
    }
}
