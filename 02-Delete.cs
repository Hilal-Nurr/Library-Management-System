using System;
using System.Linq;
public class Delete
{
    public static void DeleteBook()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- DELETE BOOK -----------");
        Console.WriteLine();

        Book? remove = null;
        string booktitle;
        while(true)
        {
            Console.Write("Which book do you want to remove : ");
            booktitle = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(booktitle))
            {
                Console.WriteLine("The book title must not be empty !!");
                continue;
            }

            remove = Menu.books.Find( x => x.BookTitle.Equals(booktitle ,StringComparison.OrdinalIgnoreCase))!;

            if (remove == null)
            {
                Console.WriteLine("Book not found !!");
                continue;
            }

            if (remove.Borrowed)
            {
                Console.WriteLine("This book is currently borrowed and cannot be deleted !!");
                continue;
            }
            break;
        }
        
        Menu.books.Remove(remove);
        
        SaveLoad.SaveBooksToFile();
        Console.WriteLine($"Book '{remove.BookTitle}' deleted successfully");
        Console.WriteLine();
        Console.ResetColor();
        
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
    public static void DeleteMember()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("----------- DELETE MEMBER -----------");
        Console.WriteLine();
        
        Member? delete = null;
        int memberID;
        while (true)
        {
            Console.Write("Enter the ID of the member to be removed : ");

            if(!int.TryParse(Console.ReadLine(), out memberID) || memberID < 2000)
            {
                Console.WriteLine("Please enter a valid number !!");
                continue;
            }
            
            delete = Menu.members.Find( x => x.ID == memberID)!; 
            
            if(delete == null)
            {
                Console.WriteLine("Member not found !!");
                continue;
            }

            if(delete.Loans.Any(a => !a.IsReturned))
            {
                Console.WriteLine("This member has borrowed books and cannot be deleted !!");
                continue;
            }
            break;
        }

        Menu.members.Remove(delete);
        
        SaveLoad.SaveMembersToFile();
        Console.WriteLine($"Member named '{delete.Name}'  has been successfully deleted");
        Console.WriteLine();
        Console.ResetColor();
        
        Console.WriteLine("Press Enter to return to the main menu ...");
        Console.ReadKey();
    }
}
