

namespace Ordering.Domain.Exceptions
{
    public class DomianException : Exception
    {
        public DomianException(string message) : base($"Domian Exception : \"{message}\" throw from Domain layer.") { }
    }
}
