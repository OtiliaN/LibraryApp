using System;
using LibraryApp.service;

namespace LibraryApp.ui
{
    public class ConsoleUI
    {
        private readonly BookService _libraryService;

        public ConsoleUI(BookService libraryService)
        {
            _libraryService = libraryService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the LibraryApp!");
            bool running = true;

            while (running)
            {
                ShowMenu();
                var choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddBook();
                            break;
                        case "2":
                            ViewAllBooks();
                            break;
                        case "3":
                            SearchBooksByTitle();
                            break;
                        case "4":
                            SearchBooksByAuthor();
                            break;
                        case "5":
                            UpdateBook();
                            break;
                        case "6":
                            RemoveBook();
                            break;
                        case "7":
                            BorrowBook();
                            break;
                        case "8":
                            ReturnBook();
                            break;
                        case "9":
                            ViewTopBorrowedBooks();
                            break;
                        case "10":
                            running = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. View all books");
            Console.WriteLine("3. Search books by title");
            Console.WriteLine("4. Search books by author");
            Console.WriteLine("5. Update a book");
            Console.WriteLine("6. Remove a book");
            Console.WriteLine("7. Borrow a book");
            Console.WriteLine("8. Return a book");
            Console.WriteLine("9. View Top Borrowed Books");
            Console.WriteLine("10. Exit");
            Console.Write("Choose an option: ");
        }

        private void AddBook()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Author: ");
            var author = Console.ReadLine();
            Console.Write("Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                _libraryService.AddBook(title, author, quantity);
                Console.WriteLine("The book was successfully added.");
            }
            else
            {
                Console.WriteLine("Quantity must be an integer.");
            }
        }

        private void ViewAllBooks()
        {
            var books = _libraryService.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library.");
            }
            else
            {
                Console.WriteLine("Available books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Quantity: {book.Quantity}");
                }
            }
        }

        private void SearchBooksByTitle()
        {
            Console.Write("Enter the title or part of the title: ");
            var title = Console.ReadLine();
            var books = _libraryService.SearchBooksByTitle(title);
            if (books.Count == 0)
            {
                Console.WriteLine("No books found with this title.");
            }
            else
            {
                Console.WriteLine("Books found:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Quantity: {book.Quantity}");
                }
            }
        }

        private void SearchBooksByAuthor()
        {
            Console.Write("Enter the author or part of the name: ");
            var author = Console.ReadLine();
            var books = _libraryService.SearchBooksByAuthor(author);
            if (books.Count == 0)
            {
                Console.WriteLine("No books found written by this author.");
            }
            else
            {
                Console.WriteLine("Books found:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Quantity: {book.Quantity}");
                }
            }
        }

        private void UpdateBook()
        {
            Console.Write("Enter the ID of the book to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("New title: ");
                var newTitle = Console.ReadLine();
                Console.Write("New author: ");
                var newAuthor = Console.ReadLine();
                Console.Write("New quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    _libraryService.UpdateBook(id, newTitle, newAuthor, newQuantity);
                    Console.WriteLine("The book was successfully updated.");
                }
                else
                {
                    Console.WriteLine("Quantity must be an integer.");
                }
            }
            else
            {
                Console.WriteLine("ID must be an integer.");
            }
        }

        private void RemoveBook()
        {
            Console.Write("Enter the ID of the book to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _libraryService.RemoveBook(id);
                Console.WriteLine("The book was removed.");
            }
            else
            {
                Console.WriteLine("ID must be an integer.");
            }
        }

        private void BorrowBook()
        {
            Console.Write("Enter the ID of the book to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _libraryService.BorrowBook(id);
                Console.WriteLine("The book was borrowed.");
            }
            else
            {
                Console.WriteLine("ID must be an integer.");
            }
        }

        private void ReturnBook()
        {
            Console.Write("Enter the ID of the book to return: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _libraryService.ReturnBook(id);
                Console.WriteLine("The book was returned.");
            }
            else
            {
                Console.WriteLine("ID must be an integer.");
            }
        }

        private void ViewTopBorrowedBooks()
        {
            var topBooks = _libraryService.GetTopBorrowedBooks();

            if (topBooks.Count == 0)
            {
                Console.WriteLine("No books have been borrowed yet.");
            }
            else
            {
                Console.WriteLine("Top Borrowed Books:");
                foreach (var book in topBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Times Borrowed: {book.TimesBorrowed}");
                }
            }
        }
    }
}