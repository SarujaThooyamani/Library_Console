using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem2
{
    internal class BookManager
    {
        private List<Book> books = new List<Book>();
        public void CreateBook(Book book)
        {
            ValidateBookRentalPrice(book);
            books.Add(book);
            Console.WriteLine("Book Added Successfully");
           

        }

        public void ReadBooks()
        {
            if (books.Count <= 0)
            {
                Console.WriteLine("No books are in the table");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.Write(book);
                }
            }
        }

        public void UpdateBook(int bookId ,string newTitle,string newAuthor,decimal newrentalPrice)
        {
            var book=books.Find(x=>x.BookId == bookId);
            if(book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                book.RentalPrice = newrentalPrice;
               books.Add(book);
                Console.WriteLine("Book updated Successfully");
            }
            else
            {
                Console.WriteLine($"can't find Book in bookId :{bookId}");
            }
        }
        public void DeleteBook(int bookId)
        {
            var book=books.Find(x=> x.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Deleted successfully");
            }
            else
            {
                Console.WriteLine($"can't find Book in bookId :{bookId}");
            }
        }
        public void ValidateBookRentalPrice(Book book)
        {
            if(book.RentalPrice <= 0)
            {
                Console.WriteLine("Book Rent Price cant't be negative try again");
                return;
            }
        }
    }
}
