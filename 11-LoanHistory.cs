using System;
using System.Linq;
public class LoanHistory
{
    public static void History()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("------------ LOAN HISTORY ------------");
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
        
        var found = Menu.members.Find(f => f.ID == memberID)!;
        
        Console.WriteLine($"Name and Surname : {found.Name} {found.Surname}");
        Console.WriteLine($"Member ID        : {memberID}");

        int number = 1;
        foreach (var member in found.Loans)
        {
            var book = Menu.books.Find(f => f.Isbn == member.Isbn);

            if(book == null)
                continue;
            
            Console.WriteLine();
            Console.WriteLine($"{number++}. {book.BookTitle}");
            Console.WriteLine($"   Author         : {book.Author}");
            Console.WriteLine($"   Borrow Date    : {member.BorrowDate:dd.MM.yyyy}");
            Console.WriteLine($"   Due Date       : {member.DueDate:dd.MM.yyyy}");
            Console.WriteLine($"   Return Date    : {(member.ReturnDate.HasValue ? member.ReturnDate.Value.ToString("dd.MM.yyyy") : "-")}");
            Console.WriteLine($"   Extension Count: {member.ExtensionCount}/3");
            Console.WriteLine($"   Status         : {(member.IsReturned ? "Returned" : "Borrowed")}");
            Console.WriteLine("---------------------------------------------");
        }
        
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadKey();
    }
}
