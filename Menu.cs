using System;
using System.Collections.Generic;
public class Menu
{
    public static List<Book> books = new List<Book>();
    public static List<Member> members = new List<Member>();
    public static void Main(string[] args)
    {
        Console.Clear();
        SaveLoad.LoadBooksFromFile();
        SaveLoad.LoadMembersFromFile();
        
        while (true)
        {
            Console.WriteLine("-----Library Management System-----");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - Add Book");
            Console.WriteLine("2 - Delete Book");
            Console.WriteLine("3 - Update Book");
            Console.WriteLine("4 - Search Book");
            Console.WriteLine("5 - List Books");
            Console.WriteLine("6 - Borrow Book");
            Console.WriteLine("7 - Return Book");
            Console.WriteLine("8 - Statistics");
            Console.WriteLine("9 - Sort Books");
            Console.WriteLine("10 - Filter Books");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("11 - Add Member");
            Console.WriteLine("12 - Delete Member");
            Console.WriteLine("13 - Update Member");
            Console.WriteLine("14 - Search Member");
            Console.WriteLine("15 - Loan History");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 - Exit");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("");
            
            Console.Write("Your Choice : ");
            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number !!");
                Console.Write("Your Choice : ");
            }

            switch (choice)
            {
                case 1:
                    Add.AddBook();
                break;

                case 2:
                    Delete.DeleteBook();
                break;
                
                case 3:
                    Update.UpdateBook();
                break;
                
                case 4:
                    Search.SearchBook();
                break;
                
                case 5:
                    ListBooks.Books();
                break;
                
                case 6:
                    BorrowBook.Borrow();
                break;
                
                case 7:
                    ReturnBook.Return();
                break;
                
                case 8:
                    Statistics.Statistic();
                break;

                case 9:
                    SortBooks.Sort();
                break;

                case 10:
                    FilterBooks.Filter();
                break;

                case 11:
                    Add.AddMember();
                break;

                case 12:
                    Delete.DeleteMember();
                break;

                case 13:
                    Update.UpdateMember();
                break;

                case 14:
                    Search.SearchMember();
                break;

                case 15:
                    LoanHistory.History();
                break;

                case 0:
                    return;
                
                default:
                    Console.WriteLine("Please enter a number between 0 and 15 !!");
                break;
            }
        }
    }
    public static void ShowBook(Book book)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Title      : {book.BookTitle}");
        Console.WriteLine($"Author     : {book.Author}");
        Console.WriteLine($"Genre      : {book.Genre}");
        Console.WriteLine($"Page Count : {book.PageCount}");
        Console.WriteLine($"Year       : {book.PublicationYear}");
        Console.WriteLine($"ISBN       : {book.Isbn}");
        Console.WriteLine($"Borrowed   : {book.Borrowed}");
        Console.WriteLine("--------------------------");
    }
}
