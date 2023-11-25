using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitsDataAccess.Repository
{
	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		private readonly JitsStoreContext _context;
		public CustomerRepository(JitsStoreContext dbcontext) : base(dbcontext)
		{
			_context = dbcontext;
		}
	}
}
