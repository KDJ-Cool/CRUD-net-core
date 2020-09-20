using System.Collections.Generic;

namespace CRUD.Controllers
{
    internal interface IRepository<T>
    {
        public List<T> Entities { get; set; }
        bool EntityExists(T entity);
    }
}