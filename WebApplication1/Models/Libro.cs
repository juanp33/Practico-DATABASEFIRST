using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Libro
{
    public int LibId { get; set; }

    public string LibNombre { get; set; } = null!;

    public string LibAutor { get; set; } = null!;

    public string LibGenero { get; set; } = null!;

    public string LibTipoProyecto { get; set; } = null!;

    public string LibStatus { get; set; } = null!;

    public virtual ICollection<Personaje> Personajes { get; set; } = new List<Personaje>();
}
