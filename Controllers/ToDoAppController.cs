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

        public IActionResult NavigateToTaskInsertPage()
        {
            return View("~/Views/InsertTask.cshtml");
        }

        public IActionResult NavigateToUpdateTaskInformation()
        {
            return View("~/Views/UpdateTaskInformation.cshtml", databaseManager.getAllData());
        }

        public IActionResult NavigateToAllTasksData()
        {
            Tuple<List<TaskModel>, List<string>> databaseDataAndColumnsNames = new Tuple<List<TaskModel>, List<string>>(
                databaseManager.getAllData(), databaseManager.getColumnsNames()
            );
            return View("~/Views/ToDoList.cshtml", databaseDataAndColumnsNames);
        }

        public IActionResult ChangeSelectedTaskStatusToDone(string taskID)
        {
            databaseManager.changeTaskStatusToDone(taskID);
            return View("~/Views/UpdateTaskInformation.cshtml", databaseManager.getAllData());
        }

        public IActionResult InsertNewTaskToDatabase(string taskName, string taskDeadline, string taskImportance)
        {
            bool isTaskInserted = true;
            //Console.WriteLine(taskName + " " + taskDeadline + " " + taskImportance);
            if(InputValidation.isTaskNameCorrect(taskName) &&
                InputValidation.isTaskImportanceCorrect(taskImportance) &&
                InputValidation.isTaskDeadlineCorrect(taskDeadline))
            {
                databaseManager.insertRow(taskName, taskDeadline, taskImportance);
            }
            else
            {
                isTaskInserted = false;
            }
            return View("~/Views/InsertTask.cshtml", isTaskInserted);
        }
    }
}
