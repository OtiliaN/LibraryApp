using LibraryApp.domain;

namespace LibraryApp.repository.interfaces;

public interface IBookRepository : IRepository<int, Book>
{
    List<Book> SearchByTitle(string title);
    List<Book> SearchByAuthor(string author);
}