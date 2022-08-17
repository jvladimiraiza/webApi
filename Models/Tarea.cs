using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;
public class Tarea
{
    // [Key]
    public Guid TareaId {get;set;}
    // [ForeignKey("CategoriaId")]
    public Guid CategoriaId {get;set;}
    // [Required]
    // [MaxLength(200)]
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public Boolean Estado {get;set;}
    public DateTime FechaCreacion {get;set;}

    public DateTime FechaUpdate {get;set;}
    public DateTime FechaDelete {get; set;}
    public virtual Categoria Categoria {get;set;}
    [NotMapped] // para omitir este campo
    public string Resumen {get;set;}
}
public enum Prioridad
{
    Baja,
    Medida,
    Alta
}