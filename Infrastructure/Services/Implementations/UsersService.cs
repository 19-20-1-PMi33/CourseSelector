﻿using Infrastructure.Services.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private CoursesContext _context;

        public UsersService(CoursesContext context)
        {
            _context = context;
        }

        public IEnumerable<AspNetUsers> GetUsers()
        {
            var users = _context.AspNetUsers.AsEnumerable();

            return users;
        }

        public IEnumerable<AspNetUsers> GetUserByCredit(string credit)
        {
            var user = _context.AspNetUsers.Where(user => user.Credit == credit);

            return user;
        }

        public bool AddUser(AspNetUsers user)
        {
            try
            {
                _context.AspNetUsers.Add(user);
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
