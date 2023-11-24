using JitsModels.Models;

namespace JitsDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //ICategoryRepository CategoryRepository { get; }
        //ICustomerRepository CustomerRepository { get; }
        //IEmployeeRepository EmployeeRepository { get; }
        //IOrderDetailRepository OrderDetailRepository { get; }
        //IOrderRepository OrderRepository { get; }
        //IProductRepository ProductRepository { get; }
        //IShipperRepository ShopperRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        //IUserRepository UserRepository { get; }
        void Save();
    }
}
