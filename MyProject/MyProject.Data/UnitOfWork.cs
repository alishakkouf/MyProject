using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyProject.Data
{
    internal class UnitOfWork(MyProjectDbContext dbContext) : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public async Task BeginTransactionAsync(IsolationLevel? isolationLevel = null)
        {
            if (_transaction == null)
            {
                if (!isolationLevel.HasValue)
                {
                    _transaction = await dbContext.Database.BeginTransactionAsync();
                }
                else
                {
                    _transaction = await dbContext.Database.BeginTransactionAsync(isolationLevel.Value);
                }
            }
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollBackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
                DetachAllEntities();
            }
        }

        private async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        private void DetachAllEntities()
        {
            var modifiedEntries = dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            modifiedEntries.ForEach(entry => entry.State = EntityState.Detached);
        }
    }
}
