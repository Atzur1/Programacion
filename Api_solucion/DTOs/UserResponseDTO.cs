namespace Api_solucion.DTOs;

using entity_library;

public class UserResponseDTO
{
    public long Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public RoleType Role { get; set; }
    public string? Token { get; set; }
}