using System;
using LibraryApp.repository.impl;
using LibraryApp.service;
using LibraryApp.ui;

namespace LibraryApp;

class Program
{
    static void Main(string[] args)
    {

        var filePath = "C:\\Users\\otili\\Desktop\\Personal\\LibraryApp\\LibraryApp\\resources\\books.json";
        
        var bookRepository = new BookRepositoryImpl(filePath);
        var libraryService = new BookService(bookRepository);

        var consoleUI = new ConsoleUI(libraryService);
        consoleUI.Run();
    }
}