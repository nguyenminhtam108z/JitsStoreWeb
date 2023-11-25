using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace JitsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _srRepo;
		protected readonly JitsStoreContext _dbcontext;
		private readonly ICacheRedis _cacheService;
        public SupplierController(ISupplierRepository srRepo , ICacheRedis cacheService , JitsStoreContext dbContext)
        {
            _srRepo = srRepo;
            _cacheService = cacheService;
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Route("api/getAllSupplier")]
        public IActionResult GetAllSupplier()
        {
            // check cache data
            var cacheData = _cacheService.GetData<IEnumerable<Supplier>>("supplier");
            if(cacheData != null && cacheData.Any())
            {
                return Ok(cacheData);
            }
            cacheData = _srRepo.GetAll();

            // set Expiry Time
            var expiryTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<IEnumerable<Supplier>>("supplier", cacheData, expiryTime);
            return Ok(cacheData);
        }

        [HttpPost]
		[Route("api/AddSupplier")]
        public IActionResult AddSupplier(Supplier supplier)
        {
            var add = _dbcontext.Suppliers.Add(supplier);
            var expriTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<Supplier>($"supplier{supplier.SupplierId}", add.Entity, expriTime);
            _dbcontext.SaveChanges();

            return Ok(add.Entity);


		}
	}
}