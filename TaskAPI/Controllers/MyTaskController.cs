using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {

      // creating methods(CRUD) to operate with our Web API and database

        private readonly DataContext _context;


        // this is the variable that allows us to connect to the database
        public MyTaskController(DataContext context)    
        {
            _context = context;
        }



        // Method of getting all tasks from db
        [HttpGet]
        public async Task<ActionResult<List<MyTask>>> Get()
        {
            return Ok(await _context.MyTasks.ToListAsync());
        }

        // Method of getting only one task from db by it's id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MyTask>>> Get(int id)
        {
            var mytask = await _context.MyTasks.FindAsync(id);
            if(mytask == null)
            {
                return BadRequest("Task not found.");
            }
            else
            {
                return Ok(mytask);
            }
            
        }


        // Method to add new task to our db
        [HttpPost]

        public async Task<ActionResult<List<MyTask>>> AddMyTask(MyTask mytask)
        {
            _context.MyTasks.Add(mytask);
            await  _context.SaveChangesAsync();
            return Ok(await _context.MyTasks.ToListAsync());
        }

        //Method to update tasks in our db
        [HttpPut]
        public async Task<ActionResult<List<MyTask>>> UpdateTask(MyTask request)
        {
            var dbmytask = await _context.MyTasks.FindAsync(request.Id);
            if (dbmytask == null)
            {
                return BadRequest("Task not found.");
            }

            dbmytask.Name = request.Name;
            dbmytask.Description = request.Description;
            dbmytask.Priority = request.Priority;


            await _context.SaveChangesAsync();

            return Ok(await _context.MyTasks.ToListAsync());
        }


        // Method that deletes task from our db by it's id 
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MyTask>>> Delete(int id)
        {
            var dbmytask = await _context.MyTasks.FindAsync(id);
            if (dbmytask == null)
            {
                return BadRequest("Task not found.");
            }
            else
            {
                _context.MyTasks.Remove(dbmytask);
                await _context.SaveChangesAsync();

                return Ok(await _context.MyTasks.ToListAsync());
            }

        }




    }
}
