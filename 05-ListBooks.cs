using System;
public class ListBooks
{
    public static void Books()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- LIST BOOKS -----------");
        Console.WriteLine();

        if (Menu.books.Count == 0)
        {
            Console.WriteLine("There are no books in the library.");
            return;
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine($" No |{"Title",-18}|{"Author",-16}|{"Genre",-13}|{"Year",-7}|{"Pages",-7}|{"ISBN",-15}|{"Borrowed",-10} ");
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
         
        int i = 1;
        foreach(Book book in Menu.books)
        {
           
            Console.WriteLine($" {i++}|{book.BookTitle,-18}|{book.Author,-16}|{book.Genre,-13}|{book.PublicationYear,-7}|{book.PageCount,-7}|{book.Isbn,-15}|{(book.Borrowed ? "Yes" : "No"),-10} ");
        }
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Total Books : {Menu.books.Count}");

        Console.ResetColor();
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
}
