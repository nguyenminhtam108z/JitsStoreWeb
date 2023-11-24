using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;

namespace JitsDataAccess.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly JitsStoreContext _dbcontext;
        public SupplierRepository(JitsStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
