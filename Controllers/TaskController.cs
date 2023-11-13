using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.Models;
using todo.Persistence;

namespace todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private Context _context { get; set; }

    public TaskController(Context ctx)
    {
        _context = ctx;
    }

    [HttpGet]
    public List<Models.Task> GetTasks()
    {
        return _context.Tasks.ToList<Models.Task>();
    }

    [HttpPost]
    public Models.Task CreateTask([FromBody]Models.Task newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();

        return newTask;
    }

    [HttpDelete("{id}")]
    public String DeleteTask([FromRoute]int TaskId)
    {
        var task = _context.Tasks.Find(TaskId);
        _ = _context.Tasks.Remove(task);

        return "Task deleted successfully";
    }
}
