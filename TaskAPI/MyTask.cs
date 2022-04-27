namespace TaskAPI
{

    // Creating an entity of task, which has id, name, description, priority as attributes.
    public class MyTask
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public int Priority { get; set; }
    }
}
