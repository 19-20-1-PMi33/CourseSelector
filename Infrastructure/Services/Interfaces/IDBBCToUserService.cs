using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.Interfaces
{
    public interface IDBBCToUserService
    {
        public IEnumerable<Dbbctouser> GetUsersDbbc();
        public IEnumerable<Dbbctouser> GetUsersDbbcByUserId(string userId);
        public bool AddDBBCToUser(Dbbctouser dbbcToUser);
        public bool Save();
    }
}
