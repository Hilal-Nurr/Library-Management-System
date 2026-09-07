# 📚 Library Management System

A C# console-based Library Management System for managing books, members, borrowing operations, and loan records.

This project was developed to practice **C#, OOP, LINQ, CRUD operations, collections, file I/O, and data persistence**.

## ✨ Features

### 📖 Book Management

* Add, delete, and update books
* List and search books
* Sort books by title, author, and publication year
* Filter books by genre, year, page count, and availability

### 👤 Member Management

* Add, delete, and update members
* Search members by ID, name, surname, and phone number
* Automatic member ID generation

### 📚 Borrowing System

* Borrow and return books
* Maximum 5 active books per member
* 15-day loan period
* Due-date extension system
* Up to 3 extensions, 10 days each

### ⏰ Late Penalty

* Automatically calculates late days
* Temporarily blocks members from borrowing based on late days

### 📋 Loan History & Statistics

* Track active and returned loans
* View borrowing and return dates
* Display library statistics

### 💾 Data Persistence

* Books are stored in `Library.txt`
* Members and loan records are stored in `Members.json`
* Data is loaded automatically when the application starts

## 🎮 Usage

```text
-----Library Management System-----

📖 BOOK MANAGEMENT
1  - Add Book
2  - Delete Book
3  - Update Book
4  - Search Book
5  - List Books
6  - Borrow Book
7  - Return Book
8  - Statistics
9  - Sort Books
10 - Filter Books

👤 MEMBER MANAGEMENT
11 - Add Member
12 - Delete Member
13 - Update Member
14 - Search Member
15 - Loan History

0  - Exit
-----------------------------------
```

The application provides an interactive console menu for managing books, members, borrowing operations, loan history, and library statistics.

## 🛠️ Technologies

* C#
* .NET 8.0
* LINQ
* Object-Oriented Programming
* JSON Serialization
* File I/O

## 🚀 Run

```bash
dotnet run
```

## 👩‍💻 Author

**Hilal Nur**

Software Engineering Student
