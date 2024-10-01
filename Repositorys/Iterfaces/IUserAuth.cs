using Sessions_app.Dtos;
using Sessions_app.Models;

namespace Sessions_app.Repositorys.Iterfaces
{
    public interface IUserAuth
    {
        Task<User> GetUserByEmail(UserLoginDto request);
        Task<User> CreateUser(UserRegisterDto request);
        void DeleteUser(int id);
    }
}
