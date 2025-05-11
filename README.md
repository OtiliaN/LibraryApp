# LibraryApp

## Description
**LibraryApp** is a console-based library management application designed to manage books, borrowing, and returning operations. The application supports features such as:
- Adding, updating, and removing books.
- Searching books by title or author.
- Borrowing and returning books.
- Viewing the Top Borrowed Books in the library.

This application is implemented in **C#** and uses **JSON files** for data persistence.

---

## Prerequisites
Before running the application, ensure the following are installed on your system:
1. **.NET SDK 6.0 or higher**: [Download .NET SDK](https://dotnet.microsoft.com/download)
2. **IDE (Optional)**: Visual Studio, JetBrains Rider, or any text editor with C# support.

---

## Configuration
The application uses a JSON file (`books.json`) located in the `resources/` directory for storing book data. Ensure the following:
1. The `books.json` file exists in the `resources/` directory.
2. The path to `books.json` is correctly set in `Program.cs`:
   ```csharp
   var filePath = "C:\\Users\\<YourUsername>\\Desktop\\LibraryApp\\LibraryApp\\resources\\books.json";
   ```

   Replace `<YourUsername>` with your system's username or the actual path where the project is located.

Example structure:
```plaintext
LibraryApp/
├── domain/
├── repository/
├── service/
├── ui/
├── resources/
│   └── books.json
├── Program.cs
└── LibraryApp.sln
```

---

## How to Run the Application

### 1. Clone the Project
1. Clone the repository:
   ```bash
   git clone <repository-link>
   ```
   Replace `<repository-link>` with the actual link.

### 2. Build the Application
1. Open a terminal in the project directory.
2. Run the following command to restore dependencies and build the project:
   ```bash
   dotnet build
   ```

### 3. Run the Application
1. Navigate to the project directory if not already there.
2. Start the application using:
   ```bash
   dotnet run
   ```

   Alternatively:
    - Open the project in your IDE.
    - Set `LibraryApp` as the startup project.
    - Press **Run** or **Start Debugging**.

---

## Functionality Overview

### Menu Options
The application presents the following menu options:
```
1. Add a book
2. View all books
3. Search books by title
4. Search books by author
5. Update a book
6. Remove a book
7. Borrow a book
8. Return a book
9. View Top Borrowed Books
10. Exit
```

### Description of Features
1. **Add a Book**: Add a new book to the library by providing the title, author, and quantity.
2. **View All Books**: Display all the books currently in the library.
3. **Search Books by Title**: Search for books based on their title.
4. **Search Books by Author**: Search for books based on the author's name.
5. **Update a Book**: Update the details of an existing book (title, author, or quantity).
6. **Remove a Book**: Delete a book from the library using its ID.
7. **Borrow a Book**: Borrow a book by its ID. This decrements the book's quantity and increments its `TimesBorrowed` counter.
8. **Return a Book**: Return a book by its ID. This increments the book's quantity.
9. **View Top Borrowed Books**: Display the top 3 most borrowed books in the library based on their `TimesBorrowed` counter.
10. **Exit**: Exit the application.

---

## Detailed Description of "Top Borrowed Books" Feature
The **Top Borrowed Books** functionality allows users to view the three most borrowed books in the library. This feature is implemented by:
1. Maintaining a `TimesBorrowed` field for each book in the JSON file (`books.json`).
2. Incrementing this field every time a book is borrowed.
3. Sorting the books based on `TimesBorrowed` in descending order.
4. Displaying the top 3 books.

Example output:
```
Top Borrowed Books:
1. ID: 2, Title: "1984", Author: "George Orwell", Times Borrowed: 15
2. ID: 1, Title: "The Great Gatsby", Author: "F. Scott Fitzgerald", Times Borrowed: 10
3. ID: 4, Title: "Pride and Prejudice", Author: "Jane Austen", Times Borrowed: 5
```

