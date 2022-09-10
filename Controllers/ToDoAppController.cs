using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TODOapp.Data;
using TODOapp.Models;

namespace TODOapp.Controllers
{
    public class ToDoAppController : Controller
    {
        private static DatabaseManagment databaseManager = new DatabaseManagment();

        public IActionResult Initialize()
        {
            databaseManager.getColumnsNames();
            return View("~/Views/MainMenu.cshtml");
        }

        public IActionResult ReturnToMainMenu()
        {
            return View("~/Views/MainMenu.cshtml");
        }

        public IActionResult RenderReturnToMainMenuPartial()
        {
            return PartialView("~/Views/Shared/_returnToMainMenu.cshtml");
        }

        public IActionResult ShowAllTasks()
        {
            Tuple<List<TaskModel>, List<string>> databaseDataAndColumnsNames =new Tuple<List<TaskModel>, List<string>>(
                databaseManager.getAllData(), databaseManager.getColumnsNames()
            );
            return View("~/Views/ToDoList.cshtml", databaseDataAndColumnsNames);
        }

        public IActionResult NavigateToTaskInsertPage()
        {
            return View("~/Views/InsertTask.cshtml");
        }

        public IActionResult InsertNewTaskToDatabase(string taskName, string taskDeadline, string taskImportance)
        {
            //Console.WriteLine(taskName + " " + taskDeadline + " " + taskImportance);
            if(InputValidation.isTaskNameCorrect(taskName) &&
                InputValidation.isTaskImportanceCorrect(taskImportance) &&
                InputValidation.isTaskDeadlineCorrect(taskDeadline))
            {
                databaseManager.insertRow(taskName, taskDeadline, taskImportance);
            }
            else
            {
                Console.WriteLine("Not correct");
            }
            return View("~/Views/InsertTask.cshtml");
        }
    }
}
