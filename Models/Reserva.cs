using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int PaqueteId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public DateOnly FechaInicioViaje { get; set; }

    public DateOnly FechaFinViaje { get; set; }

    public int NumeroPersonas { get; set; }

    public decimal PrecioTotal { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<EvaluacionesProveedore> EvaluacionesProveedores { get; set; } = new List<EvaluacionesProveedore>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual PaquetesTuristico Paquete { get; set; } = null!;

    public virtual ICollection<PersonalizacionesReserva> PersonalizacionesReservas { get; set; } = new List<PersonalizacionesReserva>();
}
