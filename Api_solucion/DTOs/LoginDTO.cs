namespace Api_solucion.DTOs;

using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Formato de email incorrecto.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Password { get; set; } = string.Empty;
}