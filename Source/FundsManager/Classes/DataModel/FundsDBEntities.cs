namespace FundsManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class FundsDBEntities : DbContext
    {
        public void discardChangesDbContextLevel()
        {
            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }

}
