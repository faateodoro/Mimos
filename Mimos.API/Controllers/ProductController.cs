using Microsoft.AspNetCore.Mvc;
using Mimos.API.Models;
using Mimos.API.Models.DTO;
using Mimos.API.Repositories;

namespace Mimos.API.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IList<Product> products;
        try
        {
            products = await _productRepository.GetAllAsync();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        Product product;
        try
        {
            product = await _productRepository.GetByIdAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok(product);
    }

    [HttpGet]
    [Route("withstock")]
    public async Task<IActionResult> GetWithStock()
    {
        IList<Product> products;
        try
        {
            products = await _productRepository.GetAllWithStockAsync();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductForm form)
    {
        Product product;
        try
        {
            product = await _productRepository.CreateAsync(form);
        }
        catch (ArgumentNullException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        return Ok(product);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromQuery] int id, [FromBody] ProductForm form)
    {
        Product product;
        try
        {
            product = await _productRepository.UpdateAsync(id, form);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok(product);
    }
}
