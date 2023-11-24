using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;

namespace JitsDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private JitsStoreContext _dbcontext;
        public ISupplierRepository SupplierRepository { get; private set; }

        public void Save(JitsStoreContext dbcontext)
        {
            this._dbcontext = dbcontext;
            SupplierRepository = new SupplierRepository(this._dbcontext);
        }

        public void Save()
        {
            this._dbcontext.SaveChanges();
        }
    }
}
