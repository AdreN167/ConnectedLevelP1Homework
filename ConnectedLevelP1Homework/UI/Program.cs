using ConnectedLevelP1Homework.Data;
using System;
using System.Reflection.Metadata;

namespace ConnectedLevelP1Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var userDataAccess = new UserDataAccess();
            var bookDataAccess = new BookDataAccess();
            var authorDataAccess = new AuthorDataAccess();

            var debtorUsers = userDataAccess.SelectDebtorUsers();
            var books = bookDataAccess.SelectAll();
            var authors = authorDataAccess.SelectAll();

            var bookNumberThree = bookDataAccess.SelectById(3);
            var userNumberTwo = userDataAccess.SelectById(2);
                
            foreach (var user in debtorUsers)
            {
                Console.WriteLine(user.ToString());
            }

            foreach (var authorId in bookNumberThree.Authors)
            {
                foreach (var author in authors)
                {
                    if (authorId == author.Id)
                    {
                        Console.WriteLine(author.ToString());
                        break;
                    }
                }
            }

            foreach (var book in books)
            {
                if (book.Status)
                {
                    Console.WriteLine(book.ToString());
                }
            }

            foreach (var bookId in userNumberTwo.Books)
            {
                foreach (var book in books)
                {
                    if (bookId == book.Id)
                    {
                        Console.WriteLine(book.ToString());
                        break;
                    }
                }
            }

            userDataAccess.UpdateDebtorUsers();
        }
    }
}
