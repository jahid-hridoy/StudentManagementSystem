using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public class StudentModel
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Course Title is required")]
    public string CourseTitle { get; set; }
    [Required(ErrorMessage = "Total Marks is required")]
    [Range(0, 100, ErrorMessage = "Total Marks must be between 0 and 100")]
    public int TotalMarks { get; set; }
    [Required(ErrorMessage = "Status is required")]
    public Status Status { get; set; }
}

public enum Status
{
    Good,
    Excellent,
    Needs_Improvement
}