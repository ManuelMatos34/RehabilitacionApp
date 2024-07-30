using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public int IdRol { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
