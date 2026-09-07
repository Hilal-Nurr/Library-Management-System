using System;
using System.Linq;
public class FilterBooks
{
    public static void Filter()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- FILTER BOOKS -----------");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Filter By");
            Console.WriteLine("1 - Genre");
            Console.WriteLine("2 - Publication Year");
            Console.WriteLine("3 - Page Count");
            Console.WriteLine("4 - Borrowed Books");
            Console.WriteLine("5 - Available Books");
            Console.WriteLine("0 - Back");
            Console.WriteLine("Choose a number between 0 and 5");
            Console.WriteLine();
            
            Console.Write("Your Choice : ");
            if(!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Please a enter a number !!");
                continue;
            }
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    FilterByGenre();
                break;
                
                case 2:
                    Console.WriteLine();
                    FilterByYear();
                break;

                case 3:
                    Console.WriteLine();
                    FilterByPage();
                break;

                case 4:
                    Console.WriteLine();
                    FilterByBorrow();
                break;

                case 5:
                    Console.WriteLine();
                    FilterByAvailable();
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
    public static void FilterByGenre()
    {
        string genre;
        while (true)
        {
            Console.Write("Enter Genre : ");
            genre = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("Please enter the genre !!");
                continue;
            }
            if(!Menu.books.Exists(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book genre not found !!");
                continue;
            }
            break;
        }
        var result = Menu.books.Where(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Genre : {genre}");
        foreach (Book book in result)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Title      : {book.BookTitle}");
            Console.WriteLine($"Author     : {book.Author}");
            Console.WriteLine($"Year       : {book.PublicationYear}");
            Console.WriteLine("--------------------------");
        }
    }
    public static void FilterByYear()
    {
        Console.Write("Enter Year : ");
        int year;
        while(true)
        {    
            if(!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Please enter a number !!");
                Console.Write("Enter Year : ");
                continue;
            }    
            if(!Menu.books.Exists(x => x.PublicationYear == year))
            {
                Console.WriteLine("Year not found !!");
                Console.Write("Enter Year : ");
                continue;
            }
            break;
        } 

        var result = Menu.books.Where(x => x.PublicationYear == year);
        Console.WriteLine($"Publication Year : {year}");
        foreach (Book book in result)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Title      : {book.BookTitle}");
            Console.WriteLine($"Author     : {book.Author}");
            Console.WriteLine($"Genre      : {book.Genre}");
            Console.WriteLine("--------------------------");
        }
    }
    public static void FilterByPage()
    {
        Console.Write("Enter Page Count : ");
        int page;
        while(true)
        {    
            if(!int.TryParse(Console.ReadLine(), out page))
            {
                Console.WriteLine("Please enter a number !!");
                Console.Write("Enter Page : ");
                continue;
            }    
            if(!Menu.books.Exists(x => x.PageCount == page))
            {
                Console.WriteLine("Page Count not found !!");
                Console.Write("Enter Page : ");
                continue;
            }
            break;
        } 

        var result = Menu.books.Where(x => x.PageCount == page);
        Console.WriteLine($"Page Count : {page}");
        foreach (Book book in result)
        {
            SortBooks.ShortShowBook(book);
        }
    }
    public static void FilterByBorrow()
    {
        Console.WriteLine("Borrowed Books");
        var borrow = Menu.books.Where(x => x.Borrowed);

        if (!borrow.Any())
        {
            Console.WriteLine("No borrowed books found.");
            return;
        }
        foreach (Book book in borrow)
        {
            SortBooks.ShortShowBook(book);
        }
    }
    public static void FilterByAvailable()
    {
        Console.WriteLine("Available Books");
        var available = Menu.books.Where(x => !x.Borrowed);

        if (!available.Any())
        {
            Console.WriteLine("No available books found.");
            return;
        }
        foreach (Book book in available)
        {
            SortBooks.ShortShowBook(book);
        }
    }
}
