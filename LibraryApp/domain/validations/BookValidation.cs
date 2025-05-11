namespace LibraryApp.domain.validations;

/// Provides validation logic for book entities.
public static class BookValidation
{
    public static void ValidateBookTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Book title cannot be empty.");
        }
    }

    public static void ValidateBookAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Book author cannot be empty.");
        }
    }

    public static void ValidateBookQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("Book quantity cannot be negative.");
        }
    }
}