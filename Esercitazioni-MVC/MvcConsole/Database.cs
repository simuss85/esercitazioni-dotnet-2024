using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public DbSet<Users> Users { get; set; } //tabella utenti
    //costruttore di default

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    //metodi di instanza
    /// <summary>
    /// Aggiunge un utente nella tabella users
    /// </summary>
    /// <param name="name">Il record da inserire nel db</param>
    public void AddUser(string name)
    {
        Users user = new Users { Name = name };
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
