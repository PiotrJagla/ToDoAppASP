using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using TODOapp.Models;

namespace TODOapp.Data
{
    public class DatabaseManagment
    {
        private MySqlConnection databaseConnection;

        public DatabaseManagment()
        {
            this.connectToDatabase();
        }

        private void connectToDatabase()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            string connectionString = configuration.GetValue<string>("ConnectionStrings:MySqlConnection");

            this.databaseConnection = new MySqlConnection(connectionString);
        }

        public List<TaskModel> getAllData()
        {
            List<TaskModel> allTasksData = new List<TaskModel>();
            databaseConnection.Open();

            MySqlCommand getAllDataSQLQuery = new MySqlCommand("SELECT * FROM tasks", databaseConnection);
            MySqlDataReader dataReader = getAllDataSQLQuery.ExecuteReader();

            while (dataReader.Read())
            {
                allTasksData.Add(new TaskModel(
                    dataReader.GetInt32(0),
                    dataReader.GetString(1),
                    dataReader.GetString(2),
                    dataReader.GetString(3),
                    dataReader.GetString(4))
                );
            }

            databaseConnection.Close();
            return allTasksData;
        }

        public List<string> getColumnsNames()
        {
            List<string> columnsNames = new List<string>();
            databaseConnection.Open();

            MySqlCommand getColumnsNames = new MySqlCommand("SELECT * FROM tasks", databaseConnection);
            MySqlDataReader dataReader = getColumnsNames.ExecuteReader();
            DataTable tableSchema = dataReader.GetSchemaTable();

            foreach (DataRow column in tableSchema.Rows)
                columnsNames.Add(
                    StringManipulation.addSpaceBeforeBigLetter(
                        column.Field<string>("ColumnName")
                    )
                );

            databaseConnection.Close();
            return columnsNames;
        }

        public List<TaskModel> getColumnData(string columnName, string searchTerm)
        {
            List<TaskModel> allDataFromQuery = new List<TaskModel>();
            databaseConnection.Open();



            MySqlCommand queryCommand = new MySqlCommand(
                "SELECT * FROM tasks WHERE " + StringManipulation.removeCharFromString(columnName, ' ') +
                " LIKE '%" + searchTerm + "%';",
                databaseConnection);
            MySqlDataReader dataReader = queryCommand.ExecuteReader();

            while (dataReader.Read())
            {
                allDataFromQuery.Add(new TaskModel(
                    dataReader.GetInt32(0),
                    dataReader.GetString(1),
                    dataReader.GetString(2),
                    dataReader.GetString(3),
                    dataReader.GetString(4))
                );
            }

            databaseConnection.Close();
            return allDataFromQuery;
        }

        public void insertRow(string taskName, string taskDeadline, string taskImportance)
        {
            databaseConnection.Open();

            MySqlCommand insertRowIntoDatabase = new MySqlCommand("INSERT INTO" +
                " tasks(Name, Deadline, IsDone, Importance) " +
                "VALUES('" + taskName + "', '" + taskDeadline + "', 'NO', '" + taskImportance + "');",
                databaseConnection
            );
            insertRowIntoDatabase.ExecuteNonQuery();

            databaseConnection.Close();
        }

        public void changeTaskStatusToDone(string taskID)
        {
            databaseConnection.Open();

            MySqlCommand insertRowIntoDatabase = new MySqlCommand(
                "UPDATE tasks " +
                "SET IsDone = 'YES'" +
                "WHERE ID =" + taskID,
                databaseConnection
            );
            insertRowIntoDatabase.ExecuteNonQuery();

            databaseConnection.Close();
        }

        public void deleteDoneTasks()
        {
            databaseConnection.Open();

            MySqlCommand insertRowIntoDatabase = new MySqlCommand(
                "DELETE FROM tasks " +
                "WHERE IsDone = 'YES'",
                databaseConnection
            );
            insertRowIntoDatabase.ExecuteNonQuery();

            databaseConnection.Close();
        }


    }
} 
