using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class PaquetesTuristico
{
    public int PaqueteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string DestinoPrincipal { get; set; } = null!;

    public int DuracionDias { get; set; }

    public decimal PrecioBase { get; set; }

    public int? CapacidadMaxima { get; set; }

    public DateOnly? FechaInicioDisponibilidad { get; set; }

    public DateOnly? FechaFinDisponibilidad { get; set; }

    public bool? Activo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Disponibilidad> Disponibilidads { get; set; } = new List<Disponibilidad>();

    public virtual ICollection<Itinerario> Itinerarios { get; set; } = new List<Itinerario>();

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
