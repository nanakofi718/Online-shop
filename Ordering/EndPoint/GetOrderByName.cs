
using Ordering.Application.Orders.Queries;

namespace Ordering.API.EndPoint
{
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
    public class GetOrderByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(orderName));

                var response = result.Adapt<GetOrdersByNameResponse>();

                return Results.Ok(response);
            })
                .WithName("GetOrderbyName")
                .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Order by Name")
                .WithDescription("Get Order by Name");
        }
    }
}
