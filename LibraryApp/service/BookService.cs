using LibraryApp.domain;
using LibraryApp.domain.validations;
using LibraryApp.repository.interfaces;

namespace LibraryApp.service;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void AddBook(string title, string author, int quantity)
    {
       
        BookValidation.ValidateBookTitle(title);
        BookValidation.ValidateBookAuthor(author);
        BookValidation.ValidateBookQuantity(quantity);

      
        var newBook = new Book(title, author, quantity)
        {
            Id = GenerateNewId()
        };
        
        _bookRepository.Add(newBook);
    }

    public void UpdateBook(int id, string newTitle, string newAuthor, int newQuantity)
    {
        BookValidation.ValidateBookTitle(newTitle);
        BookValidation.ValidateBookAuthor(newAuthor);
        BookValidation.ValidateBookQuantity(newQuantity);
        
        var bookToUpdate = _bookRepository.GetById(id);
        
        bookToUpdate.Title = newTitle;
        bookToUpdate.Author = newAuthor;
        bookToUpdate.Quantity = newQuantity;

        _bookRepository.Update(bookToUpdate);
    }

    public void RemoveBook(int id)
    {
        _bookRepository.Remove(id);
    }

    public List<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        return _bookRepository.SearchByTitle(title);
    }

    public List<Book> SearchBooksByAuthor(string author)
    {
        return _bookRepository.SearchByAuthor(author);
    }

    public void BorrowBook(int id)
    {
        var book = _bookRepository.GetById(id);

        if (book.Quantity <= 0)
        {
            throw new InvalidOperationException("The book is not available for borrowing.");
        }

        book.Quantity -= 1;
        book.TimesBorrowed += 1;
        _bookRepository.Update(book);
    }

    public void ReturnBook(int id)
    {
        var book = _bookRepository.GetById(id);

        book.Quantity += 1;
        _bookRepository.Update(book);
    }
    
    public List<Book> GetTopBorrowedBooks(int top = 3)
    {
        return _bookRepository.GetAll()
            .OrderByDescending(book => book.TimesBorrowed)
            .Take(top)
            .ToList();
    }

    private int GenerateNewId()
    {
        var allBooks = _bookRepository.GetAll();
        return allBooks.Any() ? allBooks.Max(b => b.Id) + 1 : 1;
    }
}