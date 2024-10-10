using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem2
{
    internal class BookRepository
    {
        public string connectionstring = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog = bookRentalSystem; Integrated Security = True;";

        public void Createtabe()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                        IF NOT EXISTS CREATE TABLE Books (
                        BookId INT IDENTITY(1,1) PRIMARY KEY,
                        Title NVARCHAR (50) NOT NULL,
                        Author NVARCHAR (50) NOT NULL,
                        RentalPrice DECIMAL (5, 2) NOT NULL
                            );
                        END   ";
                command.ExecuteNonQuery();
                var insertcommand = connection.CreateCommand();
                insertcommand.CommandText = @"
                        INSERT INTO Books (Title ,Author ,Rentalprice)
                        VALUES('Jeans', 'Shankar', 1.00);
                        ";
                insertcommand.ExecuteNonQuery();


            }
        }

        public void CreateBook(Book book)
        {
           
            try
            {
                
                CapitalizeTitle(book);
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO Books(Title,Author,RentalPrice)
                        VALUES(@Title,@Author,@RentalPrice)
                            ";
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book Added database Succesfully");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }

        public string CapitalizeTitle(Book book)
        {
            var words = book.Title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0])
                       + words[i].Substring(1).ToLower();
            }
            book.Title = String.Join(" ", words);
            return book.Title;
        }

        public List<Book> ReadBooks()
        {
            var books = new List<Book>();
            try
            {
                using(var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Books;", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book=new Book(
                              reader.GetInt32(0),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetDecimal(3)
                                
                              );
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in read" + ex.Message);
            }
            return books;
        }
        public void UpdateBook(Book book)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring)) 
                {
                    connection.Open();
                    var command = new SqlCommand(@"
                        UPDATE Books
                        SET Title =@Title,
                        Author=@Author,
                        RentalPrice=@RentalPrice
                        WHERE BookId=@BookId
                        ",connection);
                    command.Parameters.AddWithValue("@BookId",book.BookId);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book updated Successfully");
                }
            }
            catch (Exception ex)
            {

                Console.Write("Error " + ex.Message);

            }
        }
        public void DeleteBook(int bookid) 
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = new SqlCommand(@"
                        DELETE FROM Books
                       WHERE BookId=@bookId" 
                        , connection);
                    command.Parameters.AddWithValue("@BookId",bookid);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("cam'y find Id");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error "+ex.Message);
            }
        }
        public void GetById(int bookid)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var command = new SqlCommand(@"
                SELECT * FROM Books
                WHERE BookId=@BookId
                        ", connection);
                    command.Parameters.AddWithValue("@BookId", bookid);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var book = new Book
                            {
                                BookId = (int)reader["BookId"],
                                Title= (string)reader["Title"],
                                Author= (string)reader["Author"],
                                RentalPrice = (decimal)reader["RentalPrice"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("error" + ex.Message);
            }
        }
    }
}
