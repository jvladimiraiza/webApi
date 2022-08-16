using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;
public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*Datos iniciales*/
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId =  Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f24"), Nombre = "Actividad Pendientes", Peso = 20});

        categoriasInit.Add(new Categoria() { CategoriaId =  Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f25"), Nombre = "Actividad Personales", Peso = 50});
        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit); // hace referncia o llamado para cargar los datos iniciales
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f22"),
        CategoriaId = Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f24"), Titulo = "Pagos Pendientes", Descripcion = "Pagos de servicios publicos", PrioridadTarea = Prioridad.Medida, FechaCreacion = DateTime.Now, FechaUpdate = DateTime.Now});

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f21"),
        CategoriaId = Guid.Parse("5fa21b42-550d-4ada-9bd7-c5a7d8d63f25"), Titulo = "Pagos Servicios Basicos", Descripcion = "Pagos de servicios Basicos, Lus, agua, ect", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now, FechaUpdate = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey( t => t.TareaId);
            tarea.HasOne( t => t.Categoria).WithMany( t => t.Tareas).HasForeignKey( t => t.CategoriaId );
            tarea.Property( t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property( t => t.Estado).HasDefaultValue(true);
            tarea.Property( t => t.Descripcion);
            tarea.Property( t => t.PrioridadTarea);
            tarea.Property( t => t.FechaCreacion );
            tarea.Property( t =>  t.FechaUpdate );
            tarea.Property( t => t.FechaDelete);
            tarea.Ignore( t => t.Resumen );

            tarea.HasData(tareasInit); // agrega datos iniciales

        });
    }
}