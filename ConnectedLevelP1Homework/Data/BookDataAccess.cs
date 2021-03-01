using System.Data.SqlClient;
using System.Collections.Generic;
using ConnectedLevelP1Homework.Models;

namespace ConnectedLevelP1Homework.Data
{
    public class BookDataAccess
    {
        public Book SelectById(int id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var selectSqlScript = $"select * from Books where Id = {id}";

                var command = new SqlCommand(selectSqlScript, connection);
                var dataReader = command.ExecuteReader();

                var book = new Book();

                while (dataReader.Read())
                {

                    book.Id = int.Parse(dataReader["Id"].ToString());
                    book.Name = dataReader["Name"].ToString();
                    book.Status = bool.Parse(dataReader["Status"].ToString());
                    book.Authors = new List<int>();

                    var authorsAsText = dataReader["Authors"].ToString().Split(',');

                    foreach (var author in authorsAsText)
                    {
                        book.Authors.Add(int.Parse(author));
                    }
                }

                dataReader.Close();
                command.Dispose();

                return book;
            }
        }

        public ICollection<Book> SelectAll()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=LibraryDb; Trusted_Connection=true;";
                connection.Open();

                var selectSqlScript = $"select * from Books";

                var command = new SqlCommand(selectSqlScript, connection);
                var dataReader = command.ExecuteReader();

                var books = new List<Book>();

                while (dataReader.Read())
                {
                    var newBook = new Book
                    {
                        Id = int.Parse(dataReader["Id"].ToString()),
                        Name = dataReader["Name"].ToString(),
                        Status = bool.Parse(dataReader["Status"].ToString())
                    };

                    newBook.Authors = new List<int>();

                    var authorsAsText = dataReader["Authors"].ToString().Split(',');

                    foreach (var author in authorsAsText)
                    {
                        newBook.Authors.Add(int.Parse(author));
                    }

                    books.Add(newBook);
                }

                dataReader.Close();
                command.Dispose();

                return books;
            }
        }
    }
}
