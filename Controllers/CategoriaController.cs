using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers;
[Route("api/[controller]")]
public class CategoriaController: ControllerBase
{
    ICategoriaService categoriaService;
    public CategoriaController(ICategoriaService service)
    {
        categoriaService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.GET());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.save(categoria);
        return Ok("El registro se inserto correctamentess");
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.upadte(categoria, id);
        return Ok("El resultado se modifico correctamente");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok("El registro se elimino correctamente");
    }
}