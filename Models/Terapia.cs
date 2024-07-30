using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Terapia
{
    public int IdTerapia { get; set; }

    public DateOnly Fecha { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string Historial { get; set; } = null!;

    public string NecesidadDelPaciente { get; set; } = null!;

    public int CantidadDeTerapias { get; set; }

    public int IdPaciente { get; set; }

    public int IdEstadoTerapia { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual EstadoTerapia IdEstadoTerapiaNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
