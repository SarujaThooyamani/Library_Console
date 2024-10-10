using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            BookManager manager = new BookManager();
            int option;
            do
            {
                
                Console.WriteLine("---BookRentalManagementSystem---");
                Console.WriteLine("1.Add new Book");
                Console.WriteLine("2. Read Books ");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4. Delete a Book");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your Option");
                option=int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Book Title");
                        string title=Console.ReadLine();
                        Console.WriteLine("Enter Book Author");
                        string author=Console.ReadLine();
                        Console.WriteLine("Enter Book RentalPrice");
                        decimal price=decimal.Parse(Console.ReadLine());
                        // manager.CreateBook(new Book(title, author, price));
                        bookRepository.CreateBook(new Book(title, author, price));
                        break;
                    case 2:
                        // manager.ReadBooks();
                        var data = bookRepository.ReadBooks();
                        foreach(var item in data)
                        {

                        Console.WriteLine(item.ToString()); 
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter BookId to Update");
                        int id=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Booktitle");
                        string newtitle=Console.ReadLine();
                        Console.WriteLine("Enter New Bookauthor");
                        string newauthor=Console.ReadLine();
                        Console.WriteLine("Enter new RenyalPrice");
                        decimal newrentalPrice=decimal.Parse(Console.ReadLine());
                        //manager.UpdateBook(id, newtitle, newauthor, newrentalPrice);
                        bookRepository.UpdateBook(new Book(id, newtitle, newauthor, newrentalPrice));
                        break;
                    case 4:
                        Console.WriteLine("Enter Book Id to Delete");
                        int dltId=int.Parse(Console.ReadLine());
                      //  manager.DeleteBook(dltId);
                      bookRepository.DeleteBook(dltId);
                        break;
                    case 5:
                        Console.WriteLine("Exiting....");
                        break;
                    default:
                        Console.WriteLine("Enter Number 1 to 5");
                        break;
                }
            } while (option != 5);
        }
    }
}
