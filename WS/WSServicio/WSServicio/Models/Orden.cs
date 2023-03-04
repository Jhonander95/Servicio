using System;
using System.Collections.Generic;

namespace WSServicio.Models;

public partial class Orden
{
    public long Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal? Total { get; set; }

    public long IdCliente { get; set; }

    public string QuienRecibe { get; set; } = null!;

    public string? QuienEntrega { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public virtual ICollection<Detalle> Detalles { get; } = new List<Detalle>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
