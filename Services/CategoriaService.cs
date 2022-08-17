using webapi.Models;

namespace webapi.Services;
public class CategoriaService : ICategoriaService
{
    TareasContext context;
    public CategoriaService(TareasContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Categoria> GET()
    {
        return context.Categorias;
    }
    public async Task save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    public async Task upadte(Categoria categoria, Guid id)
    {
        try
        {
            var categoriaActual = context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;
                await context.SaveChangesAsync();
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task Delete (Guid id)
    {
        try
        {
            var categoriaActual = context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
public interface ICategoriaService
{
    IEnumerable<Categoria> GET();
    Task save(Categoria categoria);
    Task upadte(Categoria categoria, Guid id);
    Task Delete (Guid id);
}