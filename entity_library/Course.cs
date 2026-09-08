namespace entity_library;

using System.ComponentModel.DataAnnotations;

public class Course
{
    public long Id { get; set; }

    [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 150 caracteres.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
    public string? Description { get; set; }
}