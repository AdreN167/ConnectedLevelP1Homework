using System.Data.SqlClient;
using System.Collections.Generic;
using ConnectedLevelP1Homework.Models;

namespace ConnectedLevelP1Homework.Data
{
    public class AuthorDataAccess
    {

        public ICollection<Author> SelectAll()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var selectSqlScript = $"select * from Authors";

                var command = new SqlCommand(selectSqlScript, connection);
                var dataReader = command.ExecuteReader();

                var authors = new List<Author>();

                while (dataReader.Read())
                {
                    var newAuthor = new Author
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        Name = dataReader["Name"].ToString(),
                    };

                    newAuthor.Books = new List<int>();

                    var booksAsText = dataReader["Books"].ToString().Split(',');

                    foreach (var book in booksAsText)
                    {
                        newAuthor.Books.Add(int.Parse(book));
                    }

                    authors.Add(newAuthor);
                }

                dataReader.Close();
                command.Dispose();

                return authors;
            }
        }
    }
}
