# 📚 Library Management System

A feature-rich, console-based Library Management System built with C# and .NET 8.0. This application allows users to easily manage a book inventory, track borrowed books, perform advanced searches, and view library statistics. All data is persistently stored in a local text file.

## 🚀 Features

- **Book Management (CRUD):** Add, remove, and update books with comprehensive input validation (e.g., 13-digit ISBN verification).
- **Borrowing System:** Check out and return books, updating their availability status instantly.
- **Advanced Search:** Find books easily by Title, Author, Genre, or ISBN.
- **Sorting & Filtering:** 
  - Sort the library alphabetically by Title or Author, or chronologically by Publication Year.
  - Filter books by Genre, Publication Year, Page Count, or current Availability (Borrowed/Available).
- **Library Statistics:** View dynamic insights such as total books, borrowed vs. available ratios, oldest/newest books, and the most popular genre in the library.
- **Data Persistence:** Automatically loads and saves library data to a local `Library.txt` file so no information is lost between sessions.

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET 8.0
- **Features utilized:** LINQ (for querying, sorting, and filtering), File I/O (StreamWriter/StreamReader), and robust error handling.

## 📂 Data Storage Format

The application stores book records in `Library.txt` using a simple pipe-separated format:
`Title | Author | Genre | PageCount | PublicationYear | ISBN | BorrowedStatus`

*Example:*
`The Lord of the Rings | J.R.R. Tolkien | Fantasy | 1178 | 1954 | 9780544003415 | False`

## ⚙️ Prerequisites

To run this project, you need to have the [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed on your machine.

## 🏃 How to Run

1. Clone the repository or download the source code.
2. Open your terminal or command prompt.
3. Navigate to the project directory where the `.csproj` file is located.

🎮 Usage

-----Library Management System-----
1 - Add Book
2 - Remove Book
3 - Update Book
4 - Search Book
5 - List Books
6 - Borrow Book
7 - Return Book
8 - Statistics
9 - Sort Books
10 - Filter Books
0 - Exit
-----------------------------------

👩‍💻 Author

Hilal Nur

This project was created for learning C# and improving programming skills.
