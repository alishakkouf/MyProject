using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begin transaction on database with specific or no isolation level
        /// (Default Sql Server Isolation level is READ COMMITTED)
        /// </summary>
        Task BeginTransactionAsync(IsolationLevel? isolationLevel = null);

        /// <summary>
        /// Commit transaction and save to database
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Roll back transaction and undo changes on database
        /// </summary>
        Task RollBackAsync();
    }
}
