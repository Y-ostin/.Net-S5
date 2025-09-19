using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class IntentosAcceso
{
    public int IntentoId { get; set; }

    public string Email { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public bool? Exito { get; set; }

    public DateTime? FechaIntento { get; set; }
}
