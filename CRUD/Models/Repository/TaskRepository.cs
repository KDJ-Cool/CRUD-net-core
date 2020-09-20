using System.Collections.Generic;

namespace CRUD.Controllers
{
    public class TaskRepository : IRepository<Task>
    {
        public List<Task> Entities { get; set; }


        public TaskRepository()
        {
            Entities = new List<Task>();
            SeedTasks();
        }

        private void SeedTasks()
        {
            Entities.Add(new Task(1, "Test"));
            Entities.Add(new Task(2, "Homework"));
        }

        public bool EntityExists(Task entity)
        {
            return Entities.Contains(entity);
        }
    }
}