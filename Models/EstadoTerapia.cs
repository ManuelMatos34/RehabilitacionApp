using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class EstadoTerapia
{
    public int IdEstadoTerapia { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Terapia> Terapia { get; set; } = new List<Terapia>();
}
