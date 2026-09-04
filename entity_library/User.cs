namespace entity_library;

public class User : Person
{
    private string email = "";
    private string password = "";
    private RoleType roleType = RoleType.User;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public RoleType RoleType
    {
        get { return roleType; }
        set { roleType = value; }
    }
}