
using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomianEvent : INotification 
    {
        Guid Id => Guid.NewGuid();

        public DateTime OccuredOn => DateTime.Now;

        public string EvenType => GetType().AssemblyQualifiedName;
    }
}
