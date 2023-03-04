using System;
using System.Collections.Generic;

namespace WSServicio.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public long Telefono { get; set; }

    public string? Empresa { get; set; }

    public virtual ICollection<Equipo> Equipos { get; } = new List<Equipo>();

    public virtual ICollection<Orden> Ordens { get; } = new List<Orden>();

}
