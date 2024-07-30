using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Especialidade
{
    public int IdEspecialidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
