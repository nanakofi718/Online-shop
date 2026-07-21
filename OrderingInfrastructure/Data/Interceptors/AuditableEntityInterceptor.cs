
namespace Ordering.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }



        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "mehmet";
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntries())
                {
                    entry.Entity.LastModifiedBy = "mehmet";
                    entry.Entity.LastModified = DateTime.UtcNow;
                }
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntries(this Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
    {
       return entry.References.Any(r => r.TargetEntry != null && 
        r.TargetEntry.Metadata.IsOwned() && 
        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
