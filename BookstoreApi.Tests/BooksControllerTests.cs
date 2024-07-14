using BookstoreApi.Data;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class BooksControllerTests
{
    private readonly BooksController _controller;
    private readonly BookstoreContext _context;
    
public BooksControllerTests()
    {
        var options = new DbContextOptionsBuilder<BookstoreContext>()
            .UseInMemoryDatabase(databaseName: "TestBookstoreDb")
            .Options;

        _context = new BookstoreContext(options);
        _controller = new BooksController(_context);

        SeedData();
    }

    private void SeedData()
    {
        // Remove existing data to avoid conflicts
        var existingBooks = _context.Books.ToList();
        if (existingBooks.Any())
        {
            _context.Books.RemoveRange(existingBooks);
            _context.SaveChanges();
        }

        // Add new books
        _context.Books.AddRange(new List<Book>
    {
          new Book { Id = 1, Title = "Book 1", Author = "Author 1", ISBN = "123-4567890123", PublishedDate = DateTime.Now, Price = 5.99m, Quantity = 5 },
          new Book { Id = 2, Title = "Book 2", Author = "Author 2", ISBN = "456-4567890123", PublishedDate = DateTime.Now, Price = 15.99m, Quantity = 8 },
          new Book { Id = 3, Title = "Book 3", Author = "Author 2", ISBN = "789-4567890123", PublishedDate = DateTime.Now, Price = 26.99m, Quantity = 7 }
    });
        _context.SaveChanges();
    }

    
    [Fact]
    public async Task GetBook_ReturnsBook_WhenBookExists()
    {
        int testBookId = 1;
        var result = await _controller.GetBook(testBookId);

        Assert.Equal(testBookId, result.Value.Id);
    }

    [Fact]
    public async Task GetBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        int testBookId = 999;
        var result = await _controller.GetBook(testBookId);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PostBook_AddsBook_AndReturnsCreatedAtAction()
    {
        var newBook = new Book { Id = 4, Title = "New 4", Author = "Author 4", ISBN = "111-1111111111", PublishedDate = DateTime.Now, Price = 15.99m, Quantity = 8 };
        var result = await _controller.PostBook(newBook);

        var actionResult = Assert.IsType<ActionResult<Book>>(result);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var addedBook = Assert.IsType<Book>(createdAtActionResult.Value);

        Assert.Equal(newBook.Id, addedBook.Id);
        Assert.Equal(newBook.Title, addedBook.Title);
        Assert.Equal(newBook.Author, addedBook.Author);
        Assert.Equal(newBook.ISBN, addedBook.ISBN);
    }

    [Fact]
    public async Task PutBook_UpdatesBook_AndReturnsNoContent()
    {
        var updatedBook = _context.Books.First();
        updatedBook.Title = "Updated Title";
        var result = await _controller.PutBook(updatedBook.Id, updatedBook);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteBook_RemovesBook_AndReturnsNoContent()
    {
        var bookToDelete = _context.Books.First();
        var result = await _controller.DeleteBook(bookToDelete.Id);

        Assert.IsType<NoContentResult>(result);
    }
}
