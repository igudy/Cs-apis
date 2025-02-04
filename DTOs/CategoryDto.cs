using System.ComponentModel.DataAnnotations;

public class CategoryDto
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}