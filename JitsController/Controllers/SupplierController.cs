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
        private readonly ICacheRedis _cacheService;
        public SupplierController(ISupplierRepository srRepo , ICacheRedis cacheService)
        {
            _srRepo = srRepo;
            _cacheService = cacheService;
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
    }
}