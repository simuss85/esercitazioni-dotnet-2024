﻿public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();    //model
        var view = new View();   //view
        var controller = new Controller(db, view);  //controller
        controller.MainMenu();
    }
}