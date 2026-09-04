namespace dao_library;

using entity_library;

public static class MockDatabase
{
    // Ejercicio 1
    public static List<Trainer> Trainers { get; set; } = new()
    {
        new Trainer { Id = 1, Name = "Alfred Pennyworth", Age = 55, Dni = "10000001" },
        new Trainer { Id = 2, Name = "Lucius Fox", Age = 58, Dni = "10000002" }
    };

    public static List<Team> Teams { get; set; } = new()
    {
        new Team { Id = 1, Name = "Gotham Knights", Category = "Primera" },
        new Team { Id = 2, Name = "Arkham Rogues", Category = "Reserva" }
    };

    public static List<Player> Players { get; set; } = new()
    {
        new Player { Id = 1, Name = "Dick Grayson", Age = 24, Dni = "35000001", Numero = 10, Teams = new() },
        new Player { Id = 2, Name = "Jason Todd", Age = 22, Dni = "36000002", Numero = 9, Teams = new() }
    };

    // Ejercicio 2
    public static List<Student> Students { get; set; } = new()
    {
        new Student { Id = 1, Name = "Tim Drake", Age = 19, Dni = "40000001", File = "LEJ-101", Courses = new() },
        new Student { Id = 2, Name = "Damian Wayne", Age = 16, Dni = "44000002", File = "LEJ-102", Courses = new() }
    };

    public static List<Course> Courses { get; set; } = new()
    {
        new Course { Id = 1, Name = "Desarrollo de Software", Students = new(), Activities = new() },
        new Course { Id = 2, Name = "Bases de Datos", Students = new(), Activities = new() }
    };

    public static List<Activity> Activities { get; set; } = new()
    {
        new Activity { Id = 1, Title = "TP DAO", Description = "Implementar CRUD y Mocks", Date = DateTime.Now, TypeActivity = TypeActivity.Task },
        new Activity { Id = 2, Title = "Examen Parcial", Description = "C# y Arquitectura", Date = DateTime.Now.AddDays(7), TypeActivity = TypeActivity.Exam }
    };
}