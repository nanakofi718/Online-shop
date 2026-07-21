


namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomianEvent> _domianEvents = new();
        public IReadOnlyList<IDomianEvent> DomianEvents => _domianEvents.AsReadOnly();

        public void AddDomianEvent(IDomianEvent domianEvent) 
        { 
            _domianEvents.Add(domianEvent);
        }

        public IDomianEvent[] ClearDomainEvent()
        {
            IDomianEvent[] dequeueEvents = _domianEvents.ToArray();

            _domianEvents.Clear();

            return dequeueEvents;
        }
    }
}
