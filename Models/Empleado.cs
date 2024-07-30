using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int IdEspecialidad { get; set; }

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;

    public virtual ICollection<Terapia> Terapia { get; set; } = new List<Terapia>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
