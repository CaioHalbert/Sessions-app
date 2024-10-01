using Microsoft.EntityFrameworkCore;
using Sessions_app.Data;
using Sessions_app.Dtos;
using Sessions_app.Models;
using Sessions_app.Repositorys.Iterfaces;

namespace Sessions_app.Repositorys.Implementations
{
    public class UserAuth : IUserAuth
    {
        private readonly DataContext _dataContext;
        public UserAuth(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> CreateUser(UserRegisterDto request)
        {
            var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (getUser == null) 
            {
                User newUser = new User { 
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Name = request.Name,
                };
                _dataContext.Users.Add(newUser);
                _dataContext.SaveChanges();

                return newUser;
            }
            return getUser;
        }

        public void DeleteUser(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.isActive = false;
            }
        }

        public async Task<User> GetUserByEmail(UserLoginDto request)
        {
            var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (getUser == null) 
            {
                return null;
            }
            if (BCrypt.Net.BCrypt.Verify(request.Password, getUser.Password))
            {
                if (getUser.isActive)
                {
                    return getUser;
                }
                return null;
            }
            return null;
        }
    }
}
