using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class EstadoPaciente
{
    public int IdEstadoPaciente { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
