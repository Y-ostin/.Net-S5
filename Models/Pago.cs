using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int ReservaId { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string? Estado { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? ReferenciaPago { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
