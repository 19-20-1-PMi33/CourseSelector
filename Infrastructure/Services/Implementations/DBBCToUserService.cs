using Infrastructure.Services.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class DBBCToUserService : IDBBCToUserService
    {
        private CoursesContext _context;

        public DBBCToUserService(CoursesContext context)
        {
            _context = context;
        }

        public IEnumerable<Dbbctouser> GetUsersDbbc()
        {
            var allDbbc = _context.Dbbctouser.AsEnumerable();

            return allDbbc;
        }
        public IEnumerable<Dbbctouser> GetUsersDbbcByUserId(string userId)
        {
            var allDbbc = _context.Dbbctouser.AsEnumerable().Where(dbbcToUser =>
                                                                   dbbcToUser.UserId == userId);

            return allDbbc;
        }

        public bool AddDBBCToUser(Dbbctouser dbbcToUser)
        {
            try
            {
                _context.Dbbctouser.Add(dbbcToUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Dbbctouser> GetDbbcToUserByDbbcId(int? dbbcId)
        {
            var allDbbc = _context.Dbbctouser.AsEnumerable().Where(dbbcToUser =>
                                                                   dbbcToUser.Dbbcid == dbbcId);

            return allDbbc;
        }

        public bool RemoveDBBCToUser(Dbbctouser dbbcToUser)
        {
            try
            {
                var currentDbbctouser = _context.Dbbctouser.First(x => x.UserId == dbbcToUser.UserId && x.Dbbcid == dbbcToUser.Dbbcid);
                _context.Dbbctouser.Remove(currentDbbctouser);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Dbbctouser GetDBBCtoUserByIds(string UserId, int? DBBCId)
        {
            try
            {
                var dBBCtoUser = _context.Dbbctouser.First(x => x.Dbbcid == DBBCId && x.UserId == UserId);
                return dBBCtoUser;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddNotate(int? DBBCId, string UserId, string Notate)
        {
            try
            {
                var dBBCtoUser = _context.Dbbctouser.First(x => x.Dbbcid == DBBCId && x.UserId == UserId);

                if (dBBCtoUser == null)
                    return false;

                dBBCtoUser.Notate = Notate;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
