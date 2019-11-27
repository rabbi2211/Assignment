using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Data.Contracts
{
   public interface IUnitOfWork
        {
            /// <summary>
            /// Begins the transaction
            /// </summary>
            void BeginTransaction();

            /// <summary>
            /// Commits the transaction
            /// </summary>
            void Commit();

            /// <summary>
            /// Rollbacks all changes to the entities in the model.
            /// </summary>
            void Undo();
        }
    
}
