using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.DTO.BookDTO;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.domain;

namespace pagecom.cart.data.Service;

public class Bookservice : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public Bookservice(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public Task<List<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Book?> Get(int id)
    {
        var value =this._context.Books.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(value);
    }

    public Task<Book> Update(Book objectInformation)
    {
        this._context.Books.Update(objectInformation);
        this._context.SaveChanges();
        return Task.FromResult(objectInformation);
    }

    public Task<Book> Create(Book objectInformation)
    {
        var book = new Book()
        {
            Id = objectInformation.Id,
            Description = objectInformation.Description,
            Name = objectInformation.Name,
            Price = objectInformation.Price
        };
        this._context.Books.Add(book);
        this._context.SaveChanges();
        return Task.FromResult(book);
    }

    public Task Delete(Book objectInformation)
    {
        throw new NotImplementedException();
    }
}