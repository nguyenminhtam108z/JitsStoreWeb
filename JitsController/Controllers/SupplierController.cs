using JitsDataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace JitsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _srRepo;

        public SupplierController(ISupplierRepository srRepo)
        {
            _srRepo = srRepo;
        }

        [HttpGet]
        [Route("api/getAllSupplier")]
        public IActionResult GetAllSupplier()
        {
            var result = _srRepo.GetAll();

            return Ok(result);
        }
    }
}