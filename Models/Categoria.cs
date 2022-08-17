using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;
public class Categoria
{
    // [Key]
    public Guid CategoriaId {get;set;} // identificador unico
    // [Required]
    // [MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}
    [JsonIgnore] // pra obtner la iggormacioon de una coleccion
    public virtual ICollection<Tarea>  Tareas {get;set;}
}