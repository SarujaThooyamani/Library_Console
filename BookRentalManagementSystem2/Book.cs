using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem2
{
    internal class Book
    {
        public int BookId;
        public string Title;
        public string Author;
        public decimal RentalPrice;

        public static int TotalBooks;

        public Book() { }
        public Book( string title, string author, decimal rentalPrice)
        {
            
            Title = title;
            Author = author;
            RentalPrice = rentalPrice;
        }
        public Book(int bookId, string title, string author, decimal rentalPrice)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            RentalPrice = rentalPrice;
        }

        public override string ToString()
        {
            return $"ID: {BookId}, Title: {Title}, Author: {Author}, RentalPrice: {RentalPrice}";
        }

        public virtual string DisplayBookInfo()
        {
            return ToString() ;
        }
    }
    
}
