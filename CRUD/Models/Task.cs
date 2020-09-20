namespace CRUD.Controllers
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; } = false;

        public Task(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Task()
        {
        }
    }
}