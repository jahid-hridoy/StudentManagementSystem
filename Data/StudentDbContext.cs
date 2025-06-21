using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data;

public class StudentDbContext: DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
    }
    public DbSet<StudentModel> StudentList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentModel>()
            .HasData(
                new StudentModel
                {
                    Id = 1, 
                    Name = "Shakil", 
                    CourseTitle = "English",
                    TotalMarks = 85,
                    Status = Status.Excellent
                },
                new StudentModel
                {
                    Id = 2, 
                    Name = "Jahid", 
                    CourseTitle = "Mathematics",
                    TotalMarks = 30,
                    Status = Status.Needs_Improvement
                });
    }
}
