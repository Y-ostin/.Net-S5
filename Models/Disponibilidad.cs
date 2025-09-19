using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class Disponibilidad
{
    public int DisponibilidadId { get; set; }

    public int PaqueteId { get; set; }

    public DateOnly Fecha { get; set; }

    public int CapacidadDisponible { get; set; }

    public decimal? PrecioEspecial { get; set; }

    public bool? Bloqueado { get; set; }

    public virtual PaquetesTuristico Paquete { get; set; } = null!;
}
