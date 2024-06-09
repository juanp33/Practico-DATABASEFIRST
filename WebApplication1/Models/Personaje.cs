using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Personaje
{
    public int PerId { get; set; }

    public int PerLibId { get; set; }

    public int PerRolId { get; set; }

    public string PerNombre { get; set; } = null!;

    public string PerApellido { get; set; } = null!;

    public string? PerDescripcion { get; set; }

    public DateOnly PerFechaNacimiento { get; set; }

    public string PerLugarNacimiento { get; set; } = null!;

    public string PerStatus { get; set; } = null!;

    public virtual Libro PerLib { get; set; } = null!;

    public virtual Role PerRol { get; set; } = null!;
}
