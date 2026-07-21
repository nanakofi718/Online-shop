using MediatR;

namespace Ordering.Infrastructure.Data.Interceptors
{
    public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispathDomianEvent(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispathDomianEvent(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task DispathDomianEvent(DbContext? context)
        {
            if (context == null) return;

            var aggregate = context.ChangeTracker.Entries<IAggregate>()
                .Where(a => a.Entity.DomianEvents.Any())
                .Select(a => a.Entity);

            var domainEvents = aggregate
                .SelectMany(a => a.DomianEvents)
                .ToList();

            aggregate.ToList().ForEach(a => a.ClearDomainEvent());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
