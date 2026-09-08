namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class UserDAO
{
    private readonly AppDbContext _context;

    public UserDAO(AppDbContext context)
    {
        _context = context;
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetById(long id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }
}