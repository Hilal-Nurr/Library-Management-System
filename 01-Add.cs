using System;
using System.Linq;
using System.Threading;
public class Add
{
    public static void AddBook()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- ADD BOOK -----------");
        Console.WriteLine();

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
            
            if (Menu.books.Exists(book => book.BookTitle.Equals(booktitle, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This book title already exists !!");
                booktitle = "";
            }
        }while(string.IsNullOrWhiteSpace(booktitle));
        Console.WriteLine();

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
        Console.WriteLine();

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
        Console.WriteLine();
        
        Console.Write("What is the page count of this book : ");
        int pageCount;
        while(!int.TryParse(Console.ReadLine(), out pageCount) || pageCount <= 0)
        {
            Console.WriteLine("Please enter a valid number !!");
            Console.Write("What is the page count of this book : ");
        }
        Console.WriteLine();

        Console.Write("What is the publication year of this book : ");
        int publicationYear;
        while(!int.TryParse(Console.ReadLine(), out publicationYear) || publicationYear < 1600 || publicationYear > DateTime.Now.Year)
        {
            Console.WriteLine("Please enter a valid year !!");
            Console.Write("What is the publication year of this book : ");
        }
        Console.WriteLine();

        string isbn;
        do
        {
            Console.Write("What is the ISBN of this book : ");
            isbn = Console.ReadLine()!;
            
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("The ISBN must not be empty !!");
                continue;
            }
            
            if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                Console.WriteLine("The ISBN must be 13 digits long !!");
                continue;
            }
            
            if (Menu.books.Exists(book => book.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This ISBN already exists !!");
                isbn = "";
            } 
        }while(string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13);
        Console.WriteLine();

        Book book = new Book();
        book.BookTitle = booktitle;
        book.Author = author;
        book.Genre = genre;
        book.PageCount = pageCount;
        book.PublicationYear = publicationYear;
        book.Isbn = isbn;
        book.Borrowed = false;
        Menu.books.Add(book);

        using(StreamWriter sw = File.AppendText("Library.txt"))
        {
            sw.WriteLine($"{book.BookTitle} | {book.Author} | {book.Genre} | {book.PageCount} | {book.PublicationYear} | {book.Isbn} | {book.Borrowed}");
            sw.WriteLine();
        }
        
        Menu.ShowBook(book);
        Console.WriteLine($"Book '{booktitle}' added successfully!");
        Console.WriteLine();
        Console.ResetColor();
        
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
        
    }
    public static void AddMember()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("----------- ADD MEMBER -----------");
        Console.WriteLine();
        
        string name;
        while (true)
        {
            Console.Write("Enter the Member's name : ");
            name = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please do not leave it blank !!");
                continue;
            }
            break;
        }
        
        string surname;
        while (true)
        {
            Console.Write("Enter the Member's surname : ");
            surname = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Please do not leave it blank !!");
                continue;
            }
            break;
        }

        string number;
        while (true)
        {
            Console.Write("Enter the Member's phone number (05********* or 07*********) : ");
            number = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Please do not leave it blank !!");
                continue;
            }

            if(number.Length != 11 || !number.All(char.IsDigit))
            {
                Console.WriteLine("Please enter a valid number !!");
                continue;
            }

            break;
        }
        
        Console.WriteLine();
        Console.WriteLine("New member is being created ...");
        
        var memberID =  Menu.members.Any() ? Menu.members.Max(x => x.ID) + 1 : 2000;
        
        Member member = new Member();
            member.Name = name;
            member.Surname = surname;
            member.PhoneNumber = number;
            member.ID = memberID;
        Menu.members.Add(member);
        SaveLoad.SaveMembersToFile();
        
        Thread.Sleep(1500);

        Console.WriteLine("\n New Member");
        Console.WriteLine();
        Console.WriteLine($"Name : {name}");
        Console.WriteLine($"Surname : {surname}");
        Console.WriteLine($"Phone number : {number}");
        Console.WriteLine($"Member ID = {memberID}");
        Console.WriteLine("---------------------------");
        Console.WriteLine();
        Console.ResetColor();
        
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
}
