using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class PaqueteServicio
{
    public int PaqueteServicioId { get; set; }

    public int PaqueteId { get; set; }

    public int ProveedorId { get; set; }

    public string TipoServicio { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly? FechaServicio { get; set; }

    public int? Orden { get; set; }

    public virtual PaquetesTuristico Paquete { get; set; } = null!;

    public virtual Proveedore Proveedor { get; set; } = null!;
}
