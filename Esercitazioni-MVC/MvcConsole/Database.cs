using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public DbSet<User> Users { get; set; } //tabella utenti
    //costruttore di default

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseInMemoryDatabase("MyDatabase");
        optionsBuilder.UseSqlite("Data Source=data/MyDatabase.sqlite");
    }

    public void AddUser(string name)
    {
        User user = new User { Name = name };
        Users.Add(user);
        SaveChanges();
    }

    public List<string> GetUsers()
    {
        var users = Users.ToList();
        List<string> res = new();
        foreach (var user in users)
        {
            res.Add(user.Name!);
        }
        return res;
    }

    public void UpdateUser(string oldName, string name)
    {
        var users = Users.ToList();

        foreach (var user in users)
        {
            if (user.Name == oldName)
            {
                user.Name = name;
            }
        }
        SaveChanges();
    }

    public void RemoveUser(string name)
    {
        var users = Users.ToList();

        foreach (var user in users)
        {
            if (user.Name == name)
            {
                Users.Remove(user);
            }
        }
        SaveChanges();
    }
}
