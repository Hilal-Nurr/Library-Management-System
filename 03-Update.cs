using System;
using System.Linq;
public class Update
{
    public static void UpdateBook()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------- UPDATE BOOK -----------");
        Console.WriteLine();

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
            
            if (!Menu.books.Exists(book => book.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Book not found !!");
                title = "";
            }
        }while(string.IsNullOrWhiteSpace(title));

        var update = Menu.books.Find(x => x.BookTitle.Equals(title , StringComparison.OrdinalIgnoreCase))!;

        if(update.Borrowed == true)
        {
            Console.WriteLine("The book was borrowed, but you can update the book information when it is returned !!");
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu ...");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }
        
        while (true)
        {
            Console.WriteLine($"Current Book : {update.BookTitle} | {update.Author} | {update.Genre} | {update.PageCount}");
            Console.WriteLine($"{update.PublicationYear} | {update.Isbn}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Update By");
            Console.WriteLine("1 - Book Title");
            Console.WriteLine("2 - Author");
            Console.WriteLine("3 - Genre");
            Console.WriteLine("4 - Page Count");
            Console.WriteLine("5 - Publication Year");
            Console.WriteLine("0 - Back");

            int choice;
            while (true)
            {
                Console.WriteLine("Your Choice : ");

                if(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;
            }

            switch (choice)
            {
                case 1:
                    while(true)
                    {
                        Console.Write("New title : ");
                        update.BookTitle = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(update.BookTitle))
                        {
                            Console.WriteLine("The new title must not be empty !!");
                            continue;
                        }

                        if(Menu.books.Exists(x => x != update && x.BookTitle.Equals(update.BookTitle , StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("This book title already exists !!");
                            continue;
                        }
                        break;
                    }
                    SaveLoad.SaveBooksToFile();
                    Console.WriteLine("Book updated successfully");
                break;

                case 2:
                    do
                    {
                        Console.Write("New author : ");
                        update.Author = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(update.Author))
                        {
                            Console.WriteLine("The new author must not be empty !!");
                        }
                    }while(string.IsNullOrWhiteSpace(update.Author));
                    SaveLoad.SaveBooksToFile();
                    Console.WriteLine("Book updated successfully");
                break;
                
                case 3:
                    do
                    {
                        Console.Write("New genre : ");
                        update.Genre = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(update.Genre))
                        {
                            Console.WriteLine("The new genre must not be empty !!");
                        }
                    }while(string.IsNullOrWhiteSpace(update.Genre));
                    SaveLoad.SaveBooksToFile();
                    Console.WriteLine("Book updated successfully");
                break;

                case 4:
                    Console.Write("New page count : ");
                    int Page;
                    while(!int.TryParse(Console.ReadLine() , out Page) || Page <= 0)
                    {
                        Console.WriteLine("Please enter a number !!");
                        Console.Write("New page count : ");
                    }
                    update.PageCount = Page;
                    SaveLoad.SaveBooksToFile();
                    Console.WriteLine("Book updated successfully");
                break;

                case 5:
                    Console.Write("New publication year : ");
                    int year;
                    while(!int.TryParse(Console.ReadLine() , out year) || year < 1600 || year > DateTime.Now.Year)
                    {       
                        Console.WriteLine("Please enter a number !!");
                        Console.Write("New publication year : ");
                    }
                    update.PublicationYear = year;
                    SaveLoad.SaveBooksToFile();
                    Console.WriteLine("Book updated successfully");
                break;

                case 0:
                    Console.ResetColor();
                    return;
            }
        }
    }
    public static void UpdateMember()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("----------- UPDATE MEMBER -----------");
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
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Current Member");
            Console.WriteLine();
            Console.WriteLine($"Member ID    : {found.ID}");
            Console.WriteLine($"Name         : {found.Name}");
            Console.WriteLine($"Surname      : {found.Surname}");
            Console.WriteLine($"Phone Number : {found.PhoneNumber}");
            Console.WriteLine();
            Console.WriteLine($"Number of borrowed books : {found.Loans.Count(c => !c.IsReturned)}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Update By");
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Surname");
            Console.WriteLine("3 - Phone Number");
            Console.WriteLine("4 - View Borrowed Books");
            Console.WriteLine("5 - Manage Loans");
            Console.WriteLine("0 - Exit");
            Console.WriteLine();

            int choice;
            while (true)
            {
                Console.Write("Your Choice : ");

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;
            }

            switch (choice)
            {
                case 1:
                    string name;
                    while (true)
                    {
                        Console.Write("Enter new name : ");
                        name = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Please do not leave it blank !!");
                            continue;
                        }
                        break;
                    }

                    found.Name = name;
                    SaveLoad.SaveMembersToFile();

                    Console.WriteLine("Name updated successfully.");
                    Console.ReadKey();
                break;

                case 2:
                    string surname;
                    while (true)
                    {
                        Console.Write("Enter new surname : ");
                        surname = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(surname))
                        {
                            Console.WriteLine("Please do not leave it blank !!");
                            continue;
                        }
                        break;
                    }

                    found.Surname = surname;
                    SaveLoad.SaveMembersToFile();

                    Console.WriteLine("Surname updated successfully.");
                    Console.ReadKey();
                break;

                case 3:
                    string number;
                    while (true)
                    {
                        Console.Write("Enter new phone number : ");
                        number = Console.ReadLine()!;

                        if (string.IsNullOrWhiteSpace(number))
                        {
                            Console.WriteLine("Please do not leave it blank !!");
                            continue;
                        }

                        if(number.Length != 11 || !number.All(char.IsDigit))
                        {
                            Console.WriteLine("Please enter a valid phone number (It should contain 11 numbers) !!");
                            continue;
                        }
                        break;
                    }

                    found.PhoneNumber = number;
                    SaveLoad.SaveMembersToFile();

                    Console.WriteLine("Phone number updated successfully.");
                    Console.ReadKey();
                break;

                case 4:
                    int bookNumber = ViewBorrowedBooks(found, "------------ BORROWED BOOKS ------------");
                    
                    if(bookNumber == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadKey();
                    }
                break;

                case 5:
                    ManageLoans(found);
                break;

                case 0:
                    Console.ResetColor();
                    return;
            }
        }
    }
    private static int ViewBorrowedBooks(Member member, string sentence)
    {
        var activeLoans = member.Loans.Where(w => !w.IsReturned).ToList();
        Console.Clear();
        Console.WriteLine(sentence);
        Console.WriteLine();

        if(activeLoans.Count == 0)
        {
            Console.WriteLine("This member has no borrowed books.");
            Console.ResetColor();
            Console.ReadKey();
            return 0;
        }
        
        int number = 1;
        foreach (var loan in activeLoans)
        {
            var book = Menu.books.Find(f => f.Isbn == loan.Isbn);

            if(book != null)
            {
                Console.WriteLine($"{number++}. {book.BookTitle}");
                Console.WriteLine($"   Author : {book.Author}");
                Console.WriteLine($"   Borrow Date : {loan.BorrowDate:dd.MM.yyyy}");
                Console.WriteLine($"   Due Date : {loan.DueDate:dd.MM.yyyy}");
                Console.WriteLine($"   Extension Count : {loan.ExtensionCount}/3");
                Console.WriteLine("-----------------------------");
            }
        }
        return activeLoans.Count;

    }
    private static void ManageLoans(Member member)
    {
        int number = ViewBorrowedBooks(member, "------------ MANAGE LOANS ------------");
        if(number == 0)
        {
            return;
        }
        else
        {
            int select;
            while (true)
            {
                Console.Write("Select a book : ");

                if(!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > number)
                {
                    Console.WriteLine("Please enter a valid number !!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("1 - Return Book");
                Console.WriteLine("2 - Extend Due Date (The standard postponement is 10 days.)");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
            
                int choice;
                while (true)
                {
                    Console.Write("Your Choice: ");

                    if(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2)
                    {
                        Console.WriteLine("Please enter a valid number !!");
                        continue;
                    }
                    break;
                }

                switch (choice)
                {
                    case 1:
                        var activeLoans = member.Loans.Where(w => !w.IsReturned).ToList();

                        var loan = activeLoans[select-1];
                        loan.IsReturned = true;
                        loan.ReturnDate = DateTime.Now;

                        var book = Menu.books.Find(f => f.Isbn == loan.Isbn);

                        if (book != null)
                        {
                            book.Borrowed = false;
                            
                        }
                        
                        if (loan.ReturnDate.Value.Date > loan.DueDate.Date)
                        {
                            int lateDays = (loan.ReturnDate.Value.Date - loan.DueDate.Date).Days;

                            DateTime newBlockedUntil = loan.ReturnDate.Value.Date.AddDays(lateDays);

                            if (!member.BlockedUntil.HasValue || newBlockedUntil > member.BlockedUntil.Value)
                            {
                                member.BlockedUntil = newBlockedUntil;
                            }

                            Console.WriteLine();  
                            Console.WriteLine("You cannot borrow a book during the blocking period.");  
                        }
                        SaveLoad.SaveBooksToFile();
                        SaveLoad.SaveMembersToFile();
                        
                        Console.WriteLine();
                        Console.WriteLine("The book was successfully returned.");
                        Console.ReadKey();
                        return;

                    case 2:
                        var activeLoan = member.Loans.Where(w => !w.IsReturned).ToList();

                        var loans = activeLoan[select-1];
                        
                        if(loans.ExtensionCount >= 3)
                        {
                            Console.WriteLine("You can't postpone it any longer !!");
                            Console.ReadKey();
                            continue;
                        }

                        if (DateTime.Now < loans.BorrowDate.AddDays(5))
                        {
                            Console.WriteLine("You can only extend the book's due date 5 days after borrowing it .");
                            Console.ReadKey();
                            continue;
                        }

                        loans.DueDate = loans.DueDate.AddDays(10);
                        loans.ExtensionCount++;
                        
                        SaveLoad.SaveMembersToFile();

                        Console.WriteLine();
                        Console.WriteLine($"Borrow Date : {loans.BorrowDate:dd.MM.yyyy}");
                        Console.WriteLine($"Extend Due Date : {loans.DueDate:dd.MM.yyyy}");
                        Console.WriteLine($"Extension Count : {loans.ExtensionCount}");
                        Console.WriteLine();
                        
                        Console.WriteLine("It has been successfully postponed for 10 days.");
                        Console.ReadKey();
                    break;

                    case 0:
                        Console.ResetColor();
                        return;
                }
            }
        }
    }
}
