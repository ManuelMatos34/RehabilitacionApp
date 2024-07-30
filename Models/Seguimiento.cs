using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Seguimiento
{
    public int IdSeguimiento { get; set; }

    public DateOnly FechaSeguimiento { get; set; }

    public string Sensacion { get; set; } = null!;

    public bool TomoMedicamentos { get; set; }

    public bool Hielo { get; set; }

    public string? Observaciones { get; set; }

    public int Dolor { get; set; }

    public int IdEstadoPaciente { get; set; }

    public int IdTerapia { get; set; }

    public virtual EstadoPaciente IdEstadoPacienteNavigation { get; set; } = null!;

    public virtual Terapia IdTerapiaNavigation { get; set; } = null!;
}
