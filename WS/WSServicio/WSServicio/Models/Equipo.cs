using System;
using System.Collections.Generic;

namespace WSServicio.Models;

public partial class Equipo
{
    public long Id { get; set; }

    public string Modelo { get; set; } = null!;

    public string Serial { get; set; } = null!;

    public long IdCliente { get; set; }

    public virtual ICollection<Detalle> Detalles { get; } = new List<Detalle>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
