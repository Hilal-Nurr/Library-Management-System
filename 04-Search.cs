using System;
using System.Linq;
public class Search
{
    public static void SearchBook()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- SEARCH BOOK -----------");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Search By ");
            Console.WriteLine("1 - Title ");
            Console.WriteLine("2 - Author ");
            Console.WriteLine("3 - Genre ");
            Console.WriteLine("4 - ISBN ");
            Console.WriteLine("0 - Back ");
            Console.WriteLine("Choose a number between 0 and 4");
            Console.WriteLine();
            
            int choice;
            while (true)
            {
                Console.Write("Your Choice : ");
                
                if(!int.TryParse(Console.ReadLine() , out choice))
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;   
            }
            
            Console.WriteLine("------------------------------");
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
                    Console.ResetColor();
                    return;

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

            if(!Menu.books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }
            break;
        }

        Book find = Menu.books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
        Menu.ShowBook(find);
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

            if(!Menu.books.Exists(x => x.Author.Equals(author, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Author not found !!");
                continue;
            }
            break;
        }

        var found = Menu.books.Where(x => x.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        
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

            if(!Menu.books.Exists(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Genre not found !!");
                continue;
            }
            break;
        }

        var found = Menu.books.Where(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        
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
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Please enter the ISBN !!");
                continue;
            }

            if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                Console.WriteLine("The ISBN must be 13 digits long !!");
                continue;
            }
            
            if(!Menu.books.Exists(x => x.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("ISBN not found !!");
                continue;
            }
            break;
        }

        Book find = Menu.books.Find(x => x.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase))!;
        Menu.ShowBook(find);
    }
    public static void SearchMember()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- SEARCH MEMBER -----------");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Search By ");
            Console.WriteLine("1 - Member ID ");
            Console.WriteLine("2 - Name and Surname ");
            Console.WriteLine("3 - Phone Number");
            Console.WriteLine("0 - Back");
            Console.WriteLine();
            
            int choice;
            while (true)
            {
                Console.Write("Your Choice : ");
                
                if(!int.TryParse(Console.ReadLine() , out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;   
            }
            
            switch (choice)
            {
                case 1:
                    SearchByID();
                break;

                case 2:
                    SearchByName();
                break;

                case 3:
                    SearchByPhone();
                break;

                case 0:
                    Console.ResetColor();
                    return;
            }
        }
    }
    public static void SearchByID()
    {
        int memberID;
        while (true)
        {
            Console.Write("Enter Member's member ID : ");

            if(!int.TryParse(Console.ReadLine(), out memberID) || memberID < 2000)
            {
                Console.WriteLine("Please enter a valid number !!");
                continue;
            }

            if(!Menu.members.Exists(x => x.ID == memberID))
            {
                Console.WriteLine("Member not found !!");
                continue;
            }
            var member = Menu.members.Find(s => s.ID == memberID);
            Console.WriteLine();
        
            if(member == null)
            {
                Console.WriteLine("Member not found !!");
                continue;
            }
        
            ShowMember(member);
            return;
        }
    }
    public static void SearchByName()
    {
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

            if(!Menu.members.Exists(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Member not found !!");
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
            if(!Menu.members.Exists(e => e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Member not found !!");
                continue;
            }
            break;
        }

        Member selectedMember = null!;

        var member = Menu.members.FindAll(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine();
        
        if(member.Count == 0)
        {
            Console.WriteLine("Member not found !!");
            return;
        }
        else if(member.Count == 1)
        {
            selectedMember = member[0];
        }
        else
        {
            int number = 1;
            foreach(var members in member)
            {
                Console.WriteLine($" {number++}. Member ID : {members.ID}");
            }

            int select;
            while (true)
            {
                Console.Write("Select a Member : ");

                if(!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > member.Count)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;
            }
            selectedMember = member[select-1];
        }
        
        ShowMember(selectedMember);
        return;
    }
    public static void SearchByPhone()
    {
        string number;
        while (true)
        {
            Console.Write("Enter Member's phone number : ");
            number = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Please do not leave it blank !!");
                continue;
            }

            if(number.Length != 11 || !number.All(char.IsDigit))
            {
                Console.WriteLine("Please enter a valid number (It should contain 11 numbers) !!");
                continue;
            }
            break;
        }
        
        Member selectedMember = null!;

        var member = Menu.members.FindAll(s => s.PhoneNumber.Equals(number, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine();
        
        if(member.Count == 0)
        {
            Console.WriteLine("Member not found !!");
            return;
        }
        else if(member.Count == 1)
        {
            selectedMember = member[0];
        }
        else
        {
            int numbers = 1;
            foreach(var members in member)
            {
                Console.WriteLine($" {numbers++}. Member ID : {members.ID}");
            }

            int select;
            while (true)
            {
                Console.Write("Select a Member : ");

                if(!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > member.Count)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;
            }
            selectedMember = member[select-1];
        }
        
        ShowMember(selectedMember);
        return;
    }
    private static void ShowMember(Member selectedMember)
    {
        var bookCount = selectedMember.Loans.Count(c => !c.IsReturned);

        Console.WriteLine($"Name and Surname : {selectedMember.Name} {selectedMember.Surname}");
        Console.WriteLine($"Member ID : {selectedMember.ID}");
        Console.WriteLine($"Phone Number : {selectedMember.PhoneNumber}");
        Console.WriteLine($"Borrowed Books Count : {bookCount}");

        if (bookCount > 0)
        {
            Console.WriteLine("--------- Books You Borrowed ---------");

            int numbers = 1;

            foreach (var borrow in selectedMember.Loans.Where(x => !x.IsReturned))
            {
                var book = Menu.books.Find(f => f.Isbn == borrow.Isbn);

                if (book != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{numbers++}. {book.BookTitle}");
                    Console.WriteLine($"   Author         : {book.Author}");
                    Console.WriteLine($"   Borrow Date    : {borrow.BorrowDate:dd.MM.yyyy}");
                    Console.WriteLine($"   Due Date       : {borrow.DueDate:dd.MM.yyyy}");
                    Console.WriteLine($"   Return Date    : {(borrow.ReturnDate.HasValue ? borrow.ReturnDate.Value.ToString("dd.MM.yyyy") : "-")}");
                    Console.WriteLine($"   Extension Count: {borrow.ExtensionCount}/3");
                    Console.WriteLine($"   Status         : {(borrow.IsReturned ? "Returned" : "Borrowed")}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
        Console.WriteLine();
        
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
}
