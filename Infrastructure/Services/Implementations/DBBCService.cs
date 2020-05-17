using Infrastructure.Services.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services.Implementations
{
    public class DBBCService : IDBBCService
    {
        private CoursesContext _context;

        public DBBCService(CoursesContext context)
        {
            _context = context;
        }

        public IEnumerable<Dbbc> GetDBBC()
        {
            var dbbcs = _context.Dbbc.AsEnumerable();

            return dbbcs;
        }

        public bool AddDBBC(Dbbc dbbc)
        {
            try
            {
                _context.Dbbc.Add(dbbc);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
