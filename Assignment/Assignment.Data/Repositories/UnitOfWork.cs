using Assignment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Assignment.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        /// <summary>
        /// The corps context.
        /// </summary>
        private readonly AssignmentDbContext appContext;

        /// <summary>
        /// The _transaction.
        /// </summary>
        private TransactionScope transaction;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UnitOfWork(AssignmentDbContext context)
        {
            this.appContext = context;
        }

        /// <summary>
        /// Gets the corps context.
        /// </summary>
        public AssignmentDbContext AppDBContext
        {
            get { return this.appContext; }
        }

        /// <summary>
        /// Begins the transaction
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                this.transaction = new TransactionScope();
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("An error occurrred during the Begin Transaction.\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Commits the transaction
        /// </summary>
        public void Commit()
        {
            try
            {

                this.appContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured during the Commit transaction.\r\n{ex.Message}");
            }
        }

        /// <summary>
        /// The undo.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public void Undo()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured during the Rollback transaction. \r\n{ex.Message} ");
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.appContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
