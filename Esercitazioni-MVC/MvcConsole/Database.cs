using System.Data.SQLite;

public class Database
{
    private SQLiteConnection _connection;

    //costruttore di default
    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT);", _connection);
        command.ExecuteNonQuery();
    }

    //metodi di instanza
    /// <summary>
    /// Aggiunge un utente nella tabella users
    /// </summary>
    /// <param name="name">Il record da inserire nel db</param>
    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<string>();

        while (reader.Read())
        {
            users.Add(reader.GetString(0));
        }
        return users;
    }

    public void UpdateUser(string oldName, string name)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{name}' WHERE name = '{oldName}'", _connection);
        command.ExecuteNonQuery();
    }

    public void RemoveUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery();
    }
}
