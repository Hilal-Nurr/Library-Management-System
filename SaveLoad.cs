using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class SaveLoad
{
    public static void SaveBooksToFile()
    {
        using (StreamWriter sw = new StreamWriter("Library.txt"))
        {
            foreach (Book book in Menu.books)
            {
                sw.WriteLine($"{book.BookTitle} | {book.Author} | {book.Genre} | {book.PageCount} | {book.PublicationYear} | {book.Isbn} | {book.Borrowed}");
                sw.WriteLine();
            }
        }
    }
    public static void SaveMembersToFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string json = JsonSerializer.Serialize(Menu.members, options);
        File.WriteAllText("Members.json", json);
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

            Menu.books.Add(book);
        }
    }
    public static void LoadMembersFromFile()
    {
        if (!File.Exists("Members.json"))
            return;
        
        string json = File.ReadAllText("Members.json");

        var members = JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();

        Menu.members = members;
    }
}
