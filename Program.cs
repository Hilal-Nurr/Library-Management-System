using System;
using System.Collections.Generic;
using System.Linq;
public class Book()
{
    public string BookTitle { get; set; } = "";
    public string Author { get; set; } = "";
    public string Genre { get; set; } = "";
    public int PageCount { get; set; }
    public int PublicationYear{ get; set; }
    public string Isbn { get; set; } = "";
    public bool Borrowed { get; set; }
}
public class Program
{
    public static List<Book> books = new List<Book>();
    public static void Main(string[] args)
    {
        Console.Clear();
        LoadBooksFromFile();

        bool exits = false;
        while (!exits)
        {
            Console.WriteLine("-----Library Management System-----");
            Console.WriteLine("1 - Add Book");
            Console.WriteLine("2 - Remove Book");
            Console.WriteLine("3 - Update Book");
            Console.WriteLine("4 - Search Book");
            Console.WriteLine("5 - List Books");
            Console.WriteLine("6 - Borrow Book");
            Console.WriteLine("7 - Return Book");
            Console.WriteLine("8 - Statistics");
            Console.WriteLine("9 - Sort Books");
            Console.WriteLine("10 - Filter Books");
            Console.WriteLine("0 - Exit");
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
                    AddBook();
                break;

                case 2:
                    RemoveBook();
                break;
                
                case 3:
                    UpdateBook();
                break;
                
                case 4:
                    SearchBook();
                break;
                
                case 5:
                    ListBooks();
                break;
                
                case 6:
                    BorrowBook();
                break;
                
                case 7:
                    ReturnBook();
                break;
                
                case 8:
                    Statistics();
                break;

                case 9:
                    SortBooks();
                break;

                case 10:
                    FilterBooks();
                break;

                case 0:
                exits = true;
                break;
                
                default:
                    Console.WriteLine("Please enter a number between 0 and 10 !!");
                break;
            }
        }
    }
    public static void AddBook()
    {
        string booktitle;
        do
        {
            Console.Write("What is the title of the book you want to add : ");
            booktitle = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(booktitle))
            {
                Console.WriteLine("The book title must not be empty !!");
                continue;
            }
            
            if (books.Exists(book => book.BookTitle.Equals(booktitle, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This book title already exists !!");
                booktitle = "";
            }
        }while(string.IsNullOrWhiteSpace(booktitle));
        

        string author;
        do
        {
            Console.Write("Who is the author of this book : ");
            author = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("The author name must not be empty !!");
            }
        }while(string.IsNullOrWhiteSpace(author));

        string genre;
        do
        {
            Console.Write("What is the genre of this book : ");
            genre = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("The genre must not be empty !!");
            }
            
        }while(string.IsNullOrWhiteSpace(genre));
        
        Console.Write("What is the page count of this book : ");
        int pageCount;
        while(!int.TryParse(Console.ReadLine(), out pageCount) || pageCount <= 0)
        {
            Console.WriteLine("Please enter a valid number !!");
            Console.Write("What is the page count of this book : ");
        }

        Console.Write("What is the publication year of this book : ");
        int publicationYear;
        while(!int.TryParse(Console.ReadLine(), out publicationYear) || publicationYear <= 1600)
        {
            Console.WriteLine("Please enter a valid year !!");
            Console.Write("What is the publication year of this book : ");
        }

        string isbn;
        do
        {
            Console.Write("What is the ISBN of this book : ");
            isbn = Console.ReadLine()!;

             if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                Console.WriteLine("The ISBN must be 13 digits long !!");
                continue;
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("The ISBN must not be empty !!");
                continue;
            }

            if (books.Exists(book => book.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This ISBN already exists !!");
                isbn = "";
            } 
        }while(string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13);

        Book book = new Book();
        book.BookTitle = booktitle;
        book.Author = author;
        book.Genre = genre;
        book.PageCount = pageCount;
        book.PublicationYear = publicationYear;
        book.Isbn = isbn;
        book.Borrowed = false;
        books.Add(book);

        using(StreamWriter sw = File.AppendText("Library.txt"))
        {
            sw.WriteLine($"{book.BookTitle} | {book.Author} | {book.Genre} | {book.PageCount} | {book.PublicationYear} | {book.Isbn} | {book.Borrowed}");
            sw.WriteLine();
        }
        
        ShowBook(book);
        Console.WriteLine($"Book '{booktitle}' added successfully!");

        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadLine();
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
    public static void RemoveBook()
    {
        string booktitle;
        do
        {
            Console.Write("Which book do you want to remove : ");
            booktitle = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(booktitle))
            {
                Console.WriteLine("The book title must not be empty !!");
                continue;
            }
            
            if (!books.Exists(book => book.BookTitle.Equals(booktitle, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                booktitle = "";
            }
        }while(string.IsNullOrWhiteSpace(booktitle));

        Book remove = books.Find( x => x.BookTitle.Equals(booktitle ,StringComparison.OrdinalIgnoreCase))!; 
        books.Remove(remove);
        
        SaveBooksToFile();
        Console.WriteLine($"Book '{remove.BookTitle}' removed successfully");
    }
    public static void SaveBooksToFile()
    {
        using (StreamWriter sw = new StreamWriter("Library.txt"))
        {
            foreach (Book book in books)
            {
                sw.WriteLine($"{book.BookTitle} | {book.Author} | {book.Genre} | {book.PageCount} | {book.PublicationYear} | {book.Isbn} | {book.Borrowed}");
                sw.WriteLine();
            }
        }
    }
    public static void UpdateBook()
    {
        string title;
        do
        {
            Console.Write("Which book do you want to update : ");
            title = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("The book title must not be empty !!");
                continue;
            }
            
            if (!books.Exists(book => book.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                title = "";
            }
        }while(string.IsNullOrWhiteSpace(title));

        Book update = books.Find(x => x.BookTitle.Equals(title , StringComparison.OrdinalIgnoreCase))!;
        books.Remove(update);
        
        do
        {
            Console.Write("New title : ");
            update.BookTitle = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(update.BookTitle))
            {
                Console.WriteLine("The new title must not be empty !!");
                continue;
            }

            if(books.Exists(x => x.BookTitle.Equals(update.BookTitle , StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This book is available");
                update.BookTitle = "";
            }
        }while(string.IsNullOrWhiteSpace(update.BookTitle));
        
        do
        {
            Console.Write("New author : ");
            update.Author = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(update.Author))
            {
                Console.WriteLine("The new author must not be empty !!");
            }
        }while(string.IsNullOrWhiteSpace(update.Author));

        do
        {
            Console.Write("New genre : ");
            update.Genre = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(update.Genre))
            {
                Console.WriteLine("The new genre must not be empty !!");
            }
        }while(string.IsNullOrWhiteSpace(update.Genre));
        
        Console.Write("New page count : ");
        int Page;
        while(!int.TryParse(Console.ReadLine() , out Page) || Page <= 0)
        {
            Console.WriteLine("Please enter a number !!");
            Console.Write("New page count : ");
        }
        update.PageCount = Page;

        Console.Write("New publication year : ");
        int Year;
        while(!int.TryParse(Console.ReadLine() , out Year) || Year < 1600)
        {
            Console.WriteLine("Please enter a number !!");
            Console.Write("New publication year : ");
        }
        update.PublicationYear = Year;

        string isbn;
        do
        {
            Console.Write("New ISBN : ");
            isbn = Console.ReadLine()!;

            if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                Console.WriteLine("The ISBN must be 13 digits long !!");
                continue;
            }

            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("The new ISBN must not be empty !!");
                continue;
            }

            if(books.Exists(x => x.Isbn.Equals(isbn , StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This ISBN already exists !!");
                isbn = "";
            }
        }while(string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13);
        
        update.Isbn = isbn;
        books.Add(update);

        SaveBooksToFile();
        Console.WriteLine("Book updated successfully");
    }
    public static void LoadBooksFromFile()
    {
        if (!File.Exists("Library.txt"))
        {
            return;
        }

        string[] lines = File.ReadAllLines("Library.txt");

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');

            if(parts.Length != 7)
            {
                continue;
            }

            Book book = new Book();

            book.BookTitle = parts[0].Trim();
            book.Author = parts[1].Trim();
            book.Genre = parts[2].Trim();
            book.PageCount = int.Parse(parts[3].Trim());
            book.PublicationYear = int.Parse(parts[4].Trim());
            book.Isbn = parts[5].Trim();
            book.Borrowed = bool.Parse(parts[6].Trim());

            books.Add(book);
        }
    }
    public static void SearchBook()
    {
        bool stop = false;
        while (!stop)
        {
            Console.WriteLine("Search By ");
            Console.WriteLine("1 - Title ");
            Console.WriteLine("2 - Author ");
            Console.WriteLine("3 - Genre ");
            Console.WriteLine("4 - ISBN ");
            Console.WriteLine("0 - Back ");
            Console.WriteLine("Choose a number between 0 and 4");
            Console.WriteLine();
            
            Console.Write("Your Choice : ");
            int choice;
            if(!int.TryParse(Console.ReadLine() , out choice))
            {
                Console.WriteLine("Please a enter a number !!");
                continue;
            }
            switch (choice)
            {
                case 1:
                    SearchByTitle();
                break;

                case 2:
                    SearchByAuthor();
                break;

                case 3:
                    SearchByGenre();
                break;

                case 4:
                    SearchByIsbn();
                break;

                case 0:
                    stop = true;
                break;

                default:
                    Console.WriteLine("Choose a number between 0 and 4");
                break;
            } 
        }
    }
    public static void SearchByTitle()
    {
        string title;
        while (true)
        {
            Console.Write("Enter the book title you want to search for : ");
            title = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Please enter the book title !!");
                continue;
            }

            if(!books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }
            break;
        }

        Book find = books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
        ShowBook(find);
    }
    public static void SearchByAuthor()
    {
        string author;
        while (true)
        {
            Console.Write("Enter the author's name you want to search for : ");
            author = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Please enter the author !!");
                continue;
            }

            if(!books.Exists(x => x.Author.Equals(author, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Author not found !!");
                continue;
            }
            break;
        }

        var found = books.Where(x => x.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        
        Console.WriteLine($"Author : {author}");
        Console.WriteLine();

        foreach (Book founds in found)
        {
            Console.WriteLine(founds.BookTitle);
        }
    }
    public static void SearchByGenre()
    {
        string genre;
        while (true)
        {
            Console.Write("Enter the genre you want to search for : ");
            genre = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("Please enter the genre !!");
                continue;
            }

            if(!books.Exists(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Genre not found !!");
                continue;
            }
            break;
        }

        var found = books.Where(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        
        Console.WriteLine($"Genre : {genre}");
        Console.WriteLine();

        foreach (Book founds in found)
        {
            Console.WriteLine(founds.BookTitle);
        }
    }
    public static void SearchByIsbn()
    {
        string isbn;
        while (true)
        {
            Console.Write("Enter the ISBN you want to search for : ");
            isbn = Console.ReadLine()!;
            
            if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                Console.WriteLine("The ISBN must be 13 digits long !!");
                continue;
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Please enter the ISBN !!");
                continue;
            }

            if(!books.Exists(x => x.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("ISBN not found !!");
                continue;
            }
            break;
        }

        Book find = books.Find(x => x.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase))!;
        ShowBook(find);
    }
    public static void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books in the library.");
            return;
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine($" No |{"Title",-18}|{"Author",-16}|{"Genre",-13}|{"Year",-7}|{"Pages",-7}|{"ISBN",-15}|{"Borrowed",-10} ");
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
         
        int i = 1;
        foreach(Book book in books)
        {
           
            Console.WriteLine($" {i++}|{book.BookTitle,-18}|{book.Author,-16}|{book.Genre,-13}|{book.PublicationYear,-7}|{book.PageCount,-7}|{book.Isbn,-15}|{(book.Borrowed ? "Yes" : "No"),-10} ");
        }
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Total Books : {books.Count}");
    }
    public static void BorrowBook()
    {
        string title;
        while (true)
        {
            Console.Write("What is the title of the book you want to borrow : ");
            title = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Please enter the book title !!");
                continue;
            }
            if(!books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }
            Book borrow = books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
            if (borrow.Borrowed)
            {
                Console.WriteLine("This book is already borrowed. Please enter another book title");
                continue;
            }
            else
            {
                borrow.Borrowed = true;
                SaveBooksToFile();
                Console.WriteLine("Book borrowed successfully.");
                break;
            }
        }
    }
    public static void ReturnBook()
    {
        string title;
        while (true)
        {
            Console.Write("What is the title of the book you want to return : ");
            title = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Please enter the book title !!");
                continue;
            }
            if(!books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }
            Book borrow = books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
            if (!borrow.Borrowed)
            {
                Console.WriteLine("This book is not currently borrowed. Please enter another book title");
                continue;
            }
                borrow.Borrowed = false;
                SaveBooksToFile();
                Console.WriteLine("Book returned successfully.");
                break;
        }
    }
    public static void Statistics()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books.");
            return;
        }
        Console.WriteLine($"Total Books : {books.Count}");
        Console.WriteLine($"Borrowed Books : {books.Count(x => x.Borrowed)}");
        Console.WriteLine($"Available Books : {books.Count(x => !x.Borrowed)}");
        Console.WriteLine($"Oldest Book : {books.Min(x => x.PublicationYear)}");
        Console.WriteLine($"Newest Book : {books.Max(x => x.PublicationYear)}");

        var mostCommonGenre = books
                             .GroupBy(x => x.Genre)
                             .OrderByDescending(g => g.Count())
                             .FirstOrDefault();
        if(mostCommonGenre != null)
        {
            Console.WriteLine($"Most Common Genre Book : {mostCommonGenre.Key}");
            Console.WriteLine($"Number of books : {mostCommonGenre.Count()}");
        }
    }
    public static void SortBooks()
    {
        bool back = false;
        while (!back)
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
                    back = true;
                break;
                
                default:
                    Console.WriteLine("Please a enter a valid number !!");
                break;
            }
        }
    }
    public static void SortByTitle1()
    {
        var sort = books.OrderBy(x => x.BookTitle);

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
        var sort = books.OrderByDescending(x => x.BookTitle);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByAuthor1()
    {
        var sort = books.OrderBy(x => x.Author);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByAuthor2()
    {
        var sort = books.OrderByDescending(x => x.Author);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByYear1()
    {
        var sort = books.OrderBy(x => x.PublicationYear);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void SortByYear2()
    {
        var sort = books.OrderByDescending(x => x.PublicationYear);
        foreach (var book in sort)
        {
            ShortShowBook(book);
        }
    }
    public static void FilterBooks()
    {
        bool back = false;
        while (!back)
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
                    FilterByGenre();
                break;
                
                case 2:
                    FilterByYear();
                break;

                case 3:
                    FilterByPage();
                break;

                case 4:
                    FilterByBorrow();
                break;

                case 5:
                    FilterByAvailable();
                break;

                case 0:
                    back = true;
                break;

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
            if(!books.Exists(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book genre not found !!");
                continue;
            }
            break;
        }
        var result = books.Where(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
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
            if(!books.Exists(x => x.PublicationYear == year))
            {
                Console.WriteLine("Year not found !!");
                Console.Write("Enter Year : ");
                continue;
            }
            break;
        } 

        var result = books.Where(x => x.PublicationYear == year);
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
            if(!books.Exists(x => x.PageCount == page))
            {
                Console.WriteLine("Page Count not found !!");
                Console.Write("Enter Page : ");
                continue;
            }
            break;
        } 

        var result = books.Where(x => x.PageCount == page);
        Console.WriteLine($"Page Count : {page}");
        foreach (Book book in result)
        {
            ShortShowBook(book);
        }
    }
    public static void FilterByBorrow()
    {
        Console.WriteLine("Borrowed Books");
        var borrow = books.Where(x => x.Borrowed);

        if (!borrow.Any())
        {
            Console.WriteLine("No borrowed books found.");
            return;
        }
        foreach (Book book in borrow)
        {
            ShortShowBook(book);
        }
    }
    public static void FilterByAvailable()
    {
        Console.WriteLine("Available Books");
        var available = books.Where(x => !x.Borrowed);

        if (!available.Any())
        {
            Console.WriteLine("No available books found.");
            return;
        }
        foreach (Book book in available)
        {
            ShortShowBook(book);
        }
    }
}