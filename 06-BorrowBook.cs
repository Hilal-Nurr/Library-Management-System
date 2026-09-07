using System;
using System.Linq;
public class BorrowBook
{
    public static void Borrow()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- BORROW BOOK -----------");
        Console.WriteLine();

        int memberID;
        while (true)
        {
            Console.Write("Enter Member ID : ");

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
            break;
        }

        var found = Menu.members.Find( x => x.ID == memberID)!;

        if(found.BlockedUntil.HasValue && DateTime.Now.Date < found.BlockedUntil.Value.Date)
        {
            int remainingDays = (found.BlockedUntil.Value.Date - DateTime.Now.Date).Days;

            Console.WriteLine();
            Console.WriteLine("Your account is currently blocked.");
            Console.WriteLine($"Remaining days : {remainingDays}");
            Console.WriteLine($"Blocked until  : {found.BlockedUntil:dd.MM.yyyy}");
            Console.WriteLine();
            Console.WriteLine("You cannot borrow a book during the blocking period.");

            Console.ReadKey();
            return;
        }

        int activeLoans = found.Loans.Count(c => !c.IsReturned);

        if(activeLoans >= 5)
        {
            Console.WriteLine("You can borrow a maximum of 5 books, so you can't borrow any more !!");
            Console.ResetColor();
            
            Console.WriteLine("Press Enter to return to the main menu ...");
            Console.ReadKey();
            return;
        }

        Book? book = null;

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

            if(!Menu.books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }

            book = Menu.books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
            
            if (book.Borrowed)
            {
                Console.WriteLine("This book is already borrowed. Please enter another book title");
                continue;
            }
            break;
        }
        
        Console.WriteLine("Current Book");
        Console.WriteLine();
        Console.WriteLine($"Book Title : {book.BookTitle}");
        Console.WriteLine($"Author : {book.Author}");
        Console.WriteLine($"ISBN : {book.Isbn}");
        Console.WriteLine($"Publication Year : {book.PublicationYear}");
        Console.WriteLine($"Page Count : {book.PageCount}");
        
        string decision = ReturnBook.Decision("Do you approve of lending the book ? (Y or N)");
        
        if(decision == "Y")
        {
            Loan loan = new Loan
            {
                MemberId = memberID,
                Isbn = book.Isbn,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(15),
                IsReturned = false,
                ExtensionCount = 0
            };

            found.Loans.Add(loan);
            book.Borrowed = true;

            SaveLoad.SaveBooksToFile();
            SaveLoad.SaveMembersToFile();

            Console.WriteLine();
            Console.WriteLine("Book borrowed successfully.");
            Console.WriteLine($"Borrow Date: {loan.BorrowDate:dd.MM.yyyy}");
            Console.WriteLine($"Due Date: {loan.DueDate:dd.MM.yyyy}");
            Console.WriteLine();
            Console.ResetColor();
            
            Console.WriteLine("Press Enter to return to the main menu ...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Your transaction has been cancelled !!");
            Console.WriteLine();
            Console.ResetColor();
            
            Console.WriteLine("Press Enter to return to the main menu ...");
            Console.ReadKey();
        }
    }
}
