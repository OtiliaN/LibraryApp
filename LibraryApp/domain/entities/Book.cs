namespace LibraryApp.domain;

public class Book : Entity<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }
    
    public int TimesBorrowed { get; set; }
    
    public Book( string title, string author, int quantity)
    {
        Title = title;
        Author = author;
        Quantity = quantity;
        TimesBorrowed = 0;
    }
}