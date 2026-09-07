using System;
using System.Linq;
public class ReturnBook
{
    public static void Return()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- RETURN BOOK -----------");
        Console.WriteLine();

        Book? book = null;
        Loan? loan = null;
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

            if(!Menu.books.Exists(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                continue;
            }
            
            book = Menu.books.Find(x => x.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase))!;
            if (!book.Borrowed)
            {
                Console.WriteLine("This book is not currently borrowed. Please enter another book title");
                continue;
            }
            
            loan = Menu.members.SelectMany(s =>s.Loans)
                               .FirstOrDefault(s => s.Isbn == book.Isbn && !s.IsReturned);
            
            if(loan == null)
            {
                Console.WriteLine("The book could not be found on loan !!");
                continue;
            }
            
            break;
        }

        var member = Menu.members.Find(f => f.ID == loan.MemberId);
        Console.WriteLine();
        Console.WriteLine("Current Book");
        Console.WriteLine();
        Console.WriteLine($"Book Title : {book.BookTitle}");
        Console.WriteLine($"Author : {book.Author}");
        Console.WriteLine($"ISBN : {book.Isbn}");
        Console.WriteLine($"Borrow Date : {loan.BorrowDate:dd.MM.yyyy}");
        Console.WriteLine($"Due Date : {loan.DueDate:dd.MM.yyyy}");
        Console.WriteLine();
        Console.WriteLine($"Member : {member!.Name} {member!.Surname}");
        Console.WriteLine();

        string decision = Decision("Do you approve returning the book ? (Y or N)");

        if (decision == "Y")
        {
            book.Borrowed = false;

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.Now;

            if(loan.ReturnDate.Value.Date > loan.DueDate.Date)
            {
                int lateDays = (loan.ReturnDate.Value.Date - loan.DueDate.Date).Days;

                DateTime newBlockedUntil = loan.ReturnDate.Value.Date.AddDays(lateDays);

                if (!member.BlockedUntil.HasValue || newBlockedUntil > member.BlockedUntil.Value)
                {
                    member.BlockedUntil = newBlockedUntil;
                }

                Console.WriteLine($"The member cannot borrow books for {lateDays} days because the book was returned {lateDays} days late !!");
            }

            SaveLoad.SaveBooksToFile();
            SaveLoad.SaveMembersToFile();
            
            Console.WriteLine();
            Console.WriteLine("Book returned successfully.");
            Console.WriteLine($"Return Date : {loan.ReturnDate:dd.MM.yyyy}");
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
    public static string Decision(string sentence)
    {
        string decision;
        while (true)
        {
            Console.Write(sentence);
            decision = Console.ReadLine()!.ToUpper();

            if (string.IsNullOrWhiteSpace(decision))
            {
                Console.WriteLine("Please do not leave it blank !!");
                continue;
            }

            if (decision != "Y" && decision != "N")
            {
                Console.WriteLine("Please write a valid answer !!");
                continue;
            }

            break;
        }
        return decision;
    }
}
