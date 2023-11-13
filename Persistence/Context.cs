using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Persistence;

public class Context : DbContext
{
  public Context(DbContextOptions<Context> options) : base(options)
  {}

  public DbSet<Models.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Models.Task>(t => {
          t.HasKey(e => e.Id);
        });
    }
}