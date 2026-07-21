namespace Ordering.Application.Orders.Queries
{
    public class GetOrdersByNameQuery : IQuery<GetOrdersByNameResult>
    {
        public string Name { get; }

        public GetOrdersByNameQuery(string name)
        {
            Name = name;
        }
    }

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}