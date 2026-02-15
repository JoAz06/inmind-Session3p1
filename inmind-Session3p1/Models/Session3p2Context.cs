using Microsoft.EntityFrameworkCore;

namespace inmind_Session3p1.Models;

public partial class Session3p2Context : DbContext
{
    public Session3p2Context()
    {
        
    }

    public Session3p2Context(DbContextOptions<Session3p2Context> options) : base(options)
    {
        
    }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}