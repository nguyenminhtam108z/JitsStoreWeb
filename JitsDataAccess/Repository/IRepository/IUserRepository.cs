using JitsModels.Models;

namespace JitsDataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        bool login(string username, string password);
    }
}
