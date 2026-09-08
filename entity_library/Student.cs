namespace entity_library;

using System.ComponentModel.DataAnnotations;

public class Student : Person
{
    [StringLength(50, ErrorMessage = "El legajo no puede superar los 50 caracteres.")]
    public string? File { get; set; }

    public List<Course> Courses { get; set; } = new();
}