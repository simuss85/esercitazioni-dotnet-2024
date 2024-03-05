using System.Data.SQLite;
/// <summary>
/// App che permette di creare un db SQLite e di visualizzarne il contenuto
/// </summary>
public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();    //model
        var view = new View(db);   //view
        var controller = new Controller(db, view);  //controller
        controller.MainMenu();
    }
}