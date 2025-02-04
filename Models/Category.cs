using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    // Navigation property for related products(One-to-Many)
    public ICollection<Product> Products { get; set; }
}