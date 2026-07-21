using BuildingBocks.Exceptions;

namespace Ordering.Application.Exception
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid Id) : base("Order", Id)
        {
        }
    }
}
