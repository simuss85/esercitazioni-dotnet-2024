public class View
{
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Add user");
        Console.WriteLine("2. Read users");
        Console.WriteLine("3. Update user");
        Console.WriteLine("4. Delete user");
        Console.WriteLine("e. Exit");
    }

    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    public string GetInput()
    {
        return Console.ReadLine()!;  //lettura input utente
    }
}