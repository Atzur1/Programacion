using Microsoft.EntityFrameworkCore;
using entity_library;

namespace dao_library.entity_framework;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<User> Users { get; set; }
}