namespace Api_solucion.Controllers;

using Api_solucion.DTOs;
using Api_solucion.Services;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDAO _userDAO;
    private readonly JwtTokenService _jwtService;

    public UserController(UserDAO userDAO, JwtTokenService jwtService)
    {
        _userDAO = userDAO;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public ActionResult<UserResponseDTO> Register([FromBody] User user)
    {
        var existing = _userDAO.GetByEmail(user.Email);
        if (existing != null)
        {
            return BadRequest("El email ya se encuentra registrado.");
        }

        var created = _userDAO.Create(user);

        var response = new UserResponseDTO
        {
            Id = created.Id,
            Fullname = created.Name,
            Dni = created.Dni,
            Email = created.Email,
            Role = created.RoleType
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public ActionResult<UserResponseDTO> Login([FromBody] LoginDTO loginDto)
    {
        var user = _userDAO.GetByEmail(loginDto.Email);
        if (user == null)
        {
            return BadRequest("Credenciales inválidas.");
        }

        // Validación criptográfica con BCrypt
        bool passwordMatches = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
        if (!passwordMatches)
        {
            return BadRequest("Credenciales inválidas.");
        }

        // Generar JWT
        var token = _jwtService.GenerateToken(user);

        var response = new UserResponseDTO
        {
            Id = user.Id,
            Fullname = user.Name,
            Dni = user.Dni,
            Email = user.Email,
            Role = user.RoleType,
            Token = token
        };

        return Ok(response);
    }
}