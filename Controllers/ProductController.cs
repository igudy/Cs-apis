using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    // Get all products
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }

    // Get product by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProduct(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // Create product
    // [Authorize]
    // [HttpPost]
    // public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    // {
    //     var product = await _productService.CreateProduct(productDto);
    //     return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    // }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        try
        {
            var product = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    // Update product
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        var result = await _productService.UpdateProductAsync(id, productDto);
        if (!result) return NotFound();
        return NoContent();
    }

    // Delete product
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

}