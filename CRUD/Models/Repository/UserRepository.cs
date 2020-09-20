using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Controllers
{
    internal class UserRepository : IRepository<User>
    {
        public List<User> Entities { get; set; }

        public bool EntityExists(User entity)
        {
            //TODO: Verify if user exists in our db
            return true;
        }
    }
}