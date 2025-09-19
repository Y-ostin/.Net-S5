using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? ContactoNombre { get; set; }

    public string? ContactoEmail { get; set; }

    public string? ContactoTelefono { get; set; }

    public string? Direccion { get; set; }

    public decimal? CalificacionPromedio { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<EvaluacionesProveedore> EvaluacionesProveedores { get; set; } = new List<EvaluacionesProveedore>();

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();
}
