using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class Itinerario
{
    public int ItinerarioId { get; set; }

    public int PaqueteId { get; set; }

    public int DiaNumero { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Actividades { get; set; }

    public virtual PaquetesTuristico Paquete { get; set; } = null!;
}
