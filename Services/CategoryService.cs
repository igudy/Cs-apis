using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    // Get all categories
    public async Task<List<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    // Get category by id
    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    // Create category
    public async Task<Category> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    // Update category
    public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;

        await _context.SaveChangesAsync();
        return true;
    }

    // Delete category
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
