using System.Data.SqlClient;
using System.Collections.Generic;
using ConnectedLevelP1Homework.Models;
using System;

namespace ConnectedLevelP1Homework.Data
{
    public class UserDataAccess
    {
        public void UpdateDebtorUsers()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var updateSqlScript = $"Update Users set IsDebtor = 0 where IsDebtor = 1";

                var command = new SqlCommand(updateSqlScript, connection);

                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public ICollection<User> SelectDebtorUsers()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var selectSqlScript = $"select * from Users where IsDebtor = 1";

                var command = new SqlCommand(selectSqlScript, connection);
                var dataReader = command.ExecuteReader();

                var users = new List<User>();

                while (dataReader.Read())
                {
                    var newUser = new User
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        Name = dataReader["Name"].ToString(),
                        IsDebtor = bool.Parse(dataReader["IsDebtor"].ToString())
                    };

                    newUser.Books = new List<int>();

                    var booksAsText = dataReader["Books"].ToString().Split(',');

                    foreach (var book in booksAsText)
                    {
                        newUser.Books.Add(int.Parse(book));
                    }

                    users.Add(newUser);
                }

                dataReader.Close();
                command.Dispose();

                return users;
            }
        }

        public User SelectById(int id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var selectSqlScript = $"select * from Users where Id = {id}";

                var command = new SqlCommand(selectSqlScript, connection);
                var dataReader = command.ExecuteReader();

                var user = new User();

                while (dataReader.Read())
                {

                    user.Id = int.Parse(dataReader["Id"].ToString());
                    user.Name = dataReader["Name"].ToString();
                    user.IsDebtor = bool.Parse(dataReader["IsDebtor"].ToString());
                    user.Books = new List<int>();

                    var booksAsText = dataReader["Books"].ToString().Split(',');

                    foreach (var book in booksAsText)
                    {
                        user.Books.Add(int.Parse(book));
                    }
                }

                dataReader.Close();
                command.Dispose();

                return user;
            }
        }
    }
}
