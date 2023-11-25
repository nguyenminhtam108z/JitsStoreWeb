using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace JitsController.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		private ICustomerRepository _srRepo;
		private readonly ICacheRedis _cacheService;
		public CustomerController(ICustomerRepository srRepo, ICacheRedis cacheService)
		{
			_srRepo = srRepo;
			_cacheService = cacheService;
		}

		[HttpGet]
		[Route("api/getCustomer")]
		public IActionResult GetAllCustomer()
		{
			// check cache data
			var cacheData = _cacheService.GetData<IEnumerable<Customer>>("customer");
			if (cacheData != null && cacheData.Any())
			{
				return Ok(cacheData);
			}
			cacheData = _srRepo.GetAll();

			// set Expiry Time
			var expiryTime = DateTimeOffset.Now.AddSeconds(30);
			_cacheService.SetData<IEnumerable<Customer>>("customer", cacheData, expiryTime);
			return Ok(cacheData);
		}
	}
}