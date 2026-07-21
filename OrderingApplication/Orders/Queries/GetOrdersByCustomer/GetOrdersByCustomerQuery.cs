namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer
{
    public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;

    // Change this from GetOrdersByCustomerResult to OrderDto
    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
}