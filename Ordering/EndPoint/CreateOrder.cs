using Ordering.Application.Orders.Commands.CreateOrder;
namespace Ordering.API.EndPoint
{

    public record CreateOrderRequest(OrderDto Order);

    public record CreateOrderResponse(Guid Id);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender Sender) =>
            {
                var command = request.Adapt<CreateOrderCommand>();
                var result = await Sender.Send(command);
                var response = result.Adapt<CreateOrderResponse>();
                return Results.Created($"/order {response.Id}", response);
            })
                .WithName("CreateOrder")
                .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Order")
                .WithDescription("Create Order");
        }
    }
}
