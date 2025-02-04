using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Stock { get; set; }

    public string ImageUrl { get; set; }

    [Required]
    public int CategoryId { get; set; }
}