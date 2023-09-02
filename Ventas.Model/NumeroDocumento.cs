using System;
using System.Collections.Generic;

namespace Ventas_Angular14_NetCore7.Model;

public partial class NumeroDocumento
{
    public int IdNumeroDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
