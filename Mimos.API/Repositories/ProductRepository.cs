using Microsoft.EntityFrameworkCore;
using Mimos.API.Data;
using Mimos.API.Models;
using Mimos.API.Models.DTO;

namespace Mimos.API.Repositories;

public class ProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(ProductForm form)
    {
        if (form == null) throw new ArgumentNullException("Product cannot be null.");
        var product = new Product(form);
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IList<Product>> GetAllAsync()
    {
        if (!_context.Products.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var product = await _context.Products.ToListAsync();
        return product;
    }

    public async Task<IList<Product>> GetAllWithStockAsync()
    {
        if (!_context.Products.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var products = await _context.Products.Where(x => x.Amount < 0).ToListAsync();
        return products;
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        if (!_context.Products.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var product = await _context.Products.FirstAsync(x => x.Id == id);
        if (product == null) throw new KeyNotFoundException("There's no record on DB.");
        return product;
    }

    //public async Task RemoveAsync(long id)
    //{
    //    var products = await GetByIdAsync(id);
    //    if (products == null) throw new KeyNotFoundException("There's no record on DB.");
    //    products.Deactivate();
    //    _context.Update(products);
    //    await _context.SaveChangesAsync();
    //}

    public async Task<Product> UpdateAsync(long id, ProductForm form)
    {
        var product = await GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException("There's no record on DB.");
        product.Update(form);
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
