using Microsoft.EntityFrameworkCore;

// The service layer handles product business logic.

public class ProductService
{
    private readonly AppDbContext _context;

    // This context below is always added to the class
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // Get all product
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // Get product by id
    public async Task<Product> GetProduct(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    // Create product
    // public async Task<Product> CreateProduct(ProductDto productDto)
    // {
    //     var product = new Product
    //     {
    //         Name = productDto.Name,
    //         Description = productDto.Description,
    //         Price = productDto.Price,
    //         Stock = productDto.Stock,
    //         ImageUrl = productDto.ImageUrl
    //     };

    //     _context.Products.Add(product);
    //     await _context.SaveChangesAsync();
    //     return product;
    // }
    public async Task<Product> CreateProductAsync(ProductDto productDto)
    {
        var category = await _context.Categories.FindAsync(productDto.CategoryId);
        if (category == null)
        {
            throw new ArgumentException("Invalid Category ID");
        }

        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }


    // Update product
    public async Task<bool> UpdateProductAsync(int id, ProductDto productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.Stock = productDto.Stock;
        product.ImageUrl = productDto.ImageUrl;

        await _context.SaveChangesAsync();
        return true;
    }

    // Delete product
    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

}