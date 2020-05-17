﻿using Infrastructure.Services.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}