
using Assignment.Data.Contracts;
using Assignment.Data.Domains;
using Assignment.Data.Repositories;
using System.Collections.Generic;

namespace Assignment.Database.Repository
{
    public class FileProcessingRepository : Repository<STORE_ORDER>,IFileProcessingRepository
    {
        private AssignmentDbContext _dbContext;
        public FileProcessingRepository(IUnitOfWork uow) : base(uow)
        {
            
        }

        public void SaveRecords(IList<STORE_ORDER> orders)
        { 
              this.uow.AppDBContext.AddRange(orders);       
        }
    }
}
