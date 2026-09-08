namespace entity_library;

using System.ComponentModel.DataAnnotations;

public class Person
{
    public long Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(1, 120, ErrorMessage = "La edad debe estar comprendida entre 1 y 120.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "El DNI debe tener entre 6 y 20 caracteres.")]
    public string Dni { get; set; } = string.Empty;
}