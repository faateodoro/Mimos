using Microsoft.AspNetCore.Mvc;
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
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetWithStock()
    {
        var product = await _productRepository.GetAllWithStockAsync();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductForm dto)
    {
        var product = await _productRepository.CreateAsync(dto);
        return Ok(product);
    }
}
