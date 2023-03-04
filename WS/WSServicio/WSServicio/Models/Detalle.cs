using System;
using System.Collections.Generic;

namespace WSServicio.Models;

public partial class Detalle
{
    public long Id { get; set; }

    public long IdOrden { get; set; }

    public decimal Cantidad { get; set; }

    public long IdEquipo { get; set; }

    public int Cables { get; set; }

    public string? Falla { get; set; }

    public string? Diagnostico { get; set; }

    public string? Reparacion { get; set; }

    public string? Notas { get; set; }

    public string? Estado { get; set; }

    public string? Tecnico { get; set; }

    public string? QuienEntrega { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public virtual Equipo IdEquipoNavigation { get; set; } = null!;

    public virtual Orden IdOrdenNavigation { get; set; } = null!;
}
