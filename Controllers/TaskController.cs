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

    [HttpGet("{id}")]
    public Models.Task? GetTaskById([FromRoute]int id)
    {
        return _context.Tasks.Find(id);
    }

    [HttpPost]
    public Models.Task CreateTask([FromBody]Models.Task newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();

        return newTask;
    }

    [HttpPut("{TaskId}")]
    public String UpdateTask([FromRoute]int TaskId, [FromBody]Models.Task newTask)
    {
        var oldTask = _context.Tasks.Find(TaskId);
        if(oldTask != null) {
            oldTask.Title = newTask.Title;
            _context.SaveChanges();

            return "Task updated successfully";
        }

        return "Task does not exist";
    }

    [HttpDelete("{TaskId}")]
    public String DeleteTask([FromRoute]int TaskId)
    {
        var task = _context.Tasks.Find(TaskId);
        if(task != null) {
            _ = _context.Tasks.Remove(task);
            _context.SaveChanges();
        
            return "Task deleted successfully";
        }

        return "Task not found";
    }
}
