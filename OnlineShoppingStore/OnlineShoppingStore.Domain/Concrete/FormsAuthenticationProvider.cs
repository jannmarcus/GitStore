﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingStore.Domain.Abstract;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class FormsAuthenticationProvider : IAuthentication
    {
        private readonly EFDbContext context = new EFDbContext();
        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefault(u => u.UserID == username && u.Password == password);
            if (result == null)
                return false;
            return true;
        }
        

        public bool Logout()
        {
            return true;
        }
    }
}
