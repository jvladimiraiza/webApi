namespace webapi.Services;
using webapi.Models;
public class TareasServices : ITareasService
{
    TareasContext context;
    public TareasServices(TareasContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }
    public async Task save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }
    public async Task update(Tarea tarea, Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = new DateTime();
            tareaActual.FechaUpdate = new DateTime();
            tareaActual.Resumen = tarea.Resumen;
            await context.SaveChangesAsync();
        }
    }
    public async Task delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
    }
}
public interface ITareasService
{

}