using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;

namespace JitsDataAccess.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly JitsStoreContext _context;
        public SupplierRepository(JitsStoreContext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
        }
    }
}
