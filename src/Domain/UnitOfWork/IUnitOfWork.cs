using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        void Commit();
        void Rollback();
    }
}
