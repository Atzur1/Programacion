namespace entity_library;

using System.ComponentModel.DataAnnotations;

public class Activity
{
    public long Id { get; set; }

    [Required(ErrorMessage = "El título de la actividad es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 100 caracteres.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(300, ErrorMessage = "La descripción no puede superar los 300 caracteres.")]
    public string? Description { get; set; }

    public DateTime? Date { get; set; }
}