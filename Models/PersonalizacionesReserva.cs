using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class PersonalizacionesReserva
{
    public int PersonalizacionId { get; set; }

    public int ReservaId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal? CostoAdicional { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
