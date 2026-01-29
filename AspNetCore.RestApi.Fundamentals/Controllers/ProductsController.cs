using Microsoft.AspNetCore.Mvc;
using AspNetCore.RestApi.Fundamentals.Models;
using AspNetCore.RestApi.Fundamentals.Services;

namespace AspNetCore.RestApi.Fundamentals.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _service.GetById(id);
        if (product is null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product input)
    {
        var result = _service.Create(input);
        if (!result.Success) return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetById), new { id = result.Product!.Id }, result.Product);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Product> Update(int id, [FromBody] Product input)
    {
        var result = _service.Update(id, input);

        if (!result.Success && result.Error == "Product not found.")
        {
            return NotFound();
        }

        if (!result.Success)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Product);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}