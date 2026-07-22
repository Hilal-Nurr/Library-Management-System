📚 Library Management System

A simple console-based Library Management System developed in C#.

This project allows users to manage a library by adding, updating, removing, searching, sorting, and filtering books. All data is stored in a text file, so the library is saved even after the application is closed.

🚀 Features
➕ Add new books
❌ Remove books
✏️ Update book information
🔍 Search books
By Title
By Author
By Genre
By ISBN
📋 List all books
📖 Borrow books
📚 Return books
📊 View library statistics
🔃 Sort books
Title (A–Z / Z–A)
Author (A–Z / Z–A)
Publication Year
🎯 Filter books
By Genre
By Publication Year
By Page Count
Borrowed Books
Available Books
💾 Save and load data using a text file
🛠️ Technologies Used
C#
.NET
Console Application
File I/O (StreamWriter / File.ReadAllLines)
LINQ
Collections (List<T>)
📂 Data Storage

Book information is stored in a Library.txt file.

Each book contains:

Title
Author
Genre
Page Count
Publication Year
ISBN
Borrowed Status
📈 Statistics

The application displays:

Total number of books
Borrowed books
Available books
Oldest publication year
Newest publication year
Most common genre
▶️ How to Run
Clone the repository.
git clone https://github.com/yourusername/Library-Management-System.git
Open the project in Visual Studio.
Build and run the project.
A Library.txt file will be created automatically if it does not already exist.
📸 Sample Menu
----- Library Management System -----

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
💡 What I Learned

During this project, I practiced:

Object-Oriented Programming (Classes and Objects)
Methods
Lists
File Operations
Input Validation
LINQ
Sorting and Filtering
Searching
Data Persistence
Console Application Development
🔮 Future Improvements
Store data using JSON or a database
Add user authentication
Support multiple copies of the same book
Due dates for borrowed books
Better console interface
Export reports
👩‍💻 Author

Hilal Nur

This project was created for learning C# and improving programming skills.
