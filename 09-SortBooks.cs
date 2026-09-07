using System;
using System.Linq;
public class SortBooks
{
    public static void Sort()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- SORT BOOKS -----------");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Sort By");
            Console.WriteLine("1 - Title (A-Z)");
            Console.WriteLine("2 - Title (Z-A)");
            Console.WriteLine("3 - Author (A-Z)");
            Console.WriteLine("4 - Author (Z-A)");
            Console.WriteLine("5 - Publication Year (Newest-Oldest)");
            Console.WriteLine("6 - Publication Year (Oldest-Newest)");
            Console.WriteLine("0 - Back");
            Console.WriteLine("Choose a number between 0 and 6");
            Console.WriteLine();
            
            Console.Write("Your Choice : ");
            if(!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Please a enter a number !!");
                continue;
            }
            switch(choice)
            {
                case 1:
                    SortByTitle1();
                break;

                case 2:
                    SortByTitle2();
                break;
                
                case 3:
                    SortByAuthor1();
                break;
                
                case 4:
                    SortByAuthor2();
                break;
                
                case 5:
                    SortByYear1();
                break;
                
                case 6:
                    SortByYear2();
                break;
                
                case 0:
                    Console.ResetColor();
                    return;
                
                default:
                    Console.WriteLine("Please a enter a valid number !!");
                break;
            }
        }
    }
    public static void SortByTitle1()
    {
        var sort = Menu.books.OrderBy(x => x.BookTitle);

        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void ShortShowBook(Book book)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Title      : {book.BookTitle}");
        Console.WriteLine($"Author     : {book.Author}");
        Console.WriteLine($"Genre      : {book.Genre}");
        Console.WriteLine($"Year       : {book.PublicationYear}");
        Console.WriteLine("--------------------------");
    }
    public static void SortByTitle2()
    {
        var sort = Menu.books.OrderByDescending(x => x.BookTitle);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByAuthor1()
    {
        var sort = Menu.books.OrderBy(x => x.Author);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByAuthor2()
    {
        var sort = Menu.books.OrderByDescending(x => x.Author);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByYear1()
    {
        var sort = Menu.books.OrderBy(x => x.PublicationYear);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByYear2()
    {
        var sort = Menu.books.OrderByDescending(x => x.PublicationYear);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
}
