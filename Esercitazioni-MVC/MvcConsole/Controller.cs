public class Controller
{
    private Database _db;
    private View _view;
    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();   //visualizza menu principale
            var input = _view.GetInput();   //lettura input utente
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                RemoveUser();
            }
            else if (input == "e")
            {
                break;  //exit program
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        string name = _view.GetInput();
        _db.AddUser(name);
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    private void UpdateUser()
    {
        Console.WriteLine("Select user to update:");
        ShowUsers();
        string oldName = _view.GetInput();
        Console.WriteLine("Enter new name:");
        string name = _view.GetInput();
        _db.UpdateUser(oldName, name);
    }

    private void RemoveUser()
    {
        Console.WriteLine("Select user to remove:");
        ShowUsers();
        string name = _view.GetInput();
        _db.RemoveUser(name);
    }
}