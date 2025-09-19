using System;
using System.Collections.Generic;

namespace Teoria5.Models;

public partial class LogsSistema
{
    public int LogId { get; set; }

    public int? UsuarioId { get; set; }

    public string TipoOperacion { get; set; } = null!;

    public string TablaAfectada { get; set; } = null!;

    public int? RegistroId { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaOperacion { get; set; }

    public string? IpAddress { get; set; }
}
