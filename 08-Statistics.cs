using System;
using System.Linq;
public class Statistics
{
    public static void Statistic()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- STATISTICS -----------");
        Console.WriteLine();

        if (Menu.books.Count == 0)
        {
            Console.WriteLine("There are no books.");
            return;
        }
        
        Console.WriteLine($"Total Books : {Menu.books.Count}");
        Console.WriteLine($"Borrowed Books : {Menu.books.Count(x => x.Borrowed)}");
        Console.WriteLine($"Available Books : {Menu.books.Count(x => !x.Borrowed)}");
        Console.WriteLine($"Oldest Book : {Menu.books.Min(x => x.PublicationYear)}");
        Console.WriteLine($"Newest Book : {Menu.books.Max(x => x.PublicationYear)}");

        var mostCommonGenre = Menu.books
                             .GroupBy(x => x.Genre)
                             .OrderByDescending(g => g.Count())
                             .FirstOrDefault();
        if(mostCommonGenre != null)
        {
            Console.WriteLine($"Most Common Genre Book : {mostCommonGenre.Key}");
            Console.WriteLine($"Number of books : {mostCommonGenre.Count()}");
        }

        Console.ResetColor();
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
}
