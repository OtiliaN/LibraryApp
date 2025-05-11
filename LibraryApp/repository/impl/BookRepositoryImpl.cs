using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using LibraryApp.domain;
using LibraryApp.repository.interfaces;

namespace LibraryApp.repository.impl;

public class BookRepositoryImpl : IBookRepository{
    private readonly string _filePath;
    private List<Book> _books;

    public BookRepositoryImpl(string filePath)
    {
        _filePath = filePath;
        _books = LoadFromFile();
    }

    private List<Book> LoadFromFile()
    {
        if (!File.Exists(_filePath))
            return new List<Book>();

        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
    }

    private void SaveToFile()
    {
        var json = JsonConvert.SerializeObject(_books, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public void Add(Book book)
    {
        if (_books.Any(b => b.Id == book.Id))
            throw new ArgumentException("A book with the same ID already exists.");
        _books.Add(book);
        SaveToFile();
    }

    public void Remove(int id)
    {
        var book = GetById(id);
        _books.Remove(book);
        SaveToFile();
    }

    public void Update(Book updatedBook)
    {
        var index = _books.FindIndex(b => b.Id == updatedBook.Id);
        if (index == -1)
            throw new KeyNotFoundException("Book not found.");
        _books[index] = updatedBook;
        SaveToFile();
    }

    public Book GetById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id)
               ?? throw new KeyNotFoundException("Book not found.");
    }

    public List<Book> GetAll() => new(_books);

    public List<Book> SearchByTitle(string title)
    {
        return _books
            .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Book> SearchByAuthor(string author)
    {
        return _books
            .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}