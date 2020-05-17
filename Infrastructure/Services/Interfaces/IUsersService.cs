using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<AspNetUsers> GetUsers();
        public IEnumerable<AspNetUsers> GetUserByCredit(string credit);
    }
}
