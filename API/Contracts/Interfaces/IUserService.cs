using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);

        void SetLoggedInUser(User user);

        User GetLoggedInUser();
    }
}