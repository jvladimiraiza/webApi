using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareaController: ControllerBase
{
    ITareasService tareaService;
    public TareaController(ITareasService service)
    {
        tareaService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.save(tarea);
        return Ok("El registro se inserto correctamente");
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.update(tarea, id);
        return Ok("El registro se modifico correctamente");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.delete(id);
        return Ok("El registro se elimino correctamente");
    }
}