using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Stock { get; set; }  // Quantity available

    public string ImageUrl { get; set; }

    // One to many relationship with category
    // This is the link
    // CategoryId: Foreign key that links the product to a category.
    // Category: Navigation property for accessing the related category.
    [Required]
    public int CategoryId { get; set; } // Foreign key

    [ForeignKey("CategoryId")]
    public Category Category { get; set; } // Navigation property

}