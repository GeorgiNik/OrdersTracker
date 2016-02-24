using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTemplate.Services.Data
{
    using System.Security.AccessControl;

    using MvcTemplate.Data;
    using MvcTemplate.Services.Data.Contracts;

    public class UserService:IUserService
    {
        private ApplicationDbContext context;

        public UserService()
        {
            this.context=new ApplicationDbContext();
        }

        public int GetUsersCount()
        {
            return this.context.Users.Count();
        }

        

    }
}
