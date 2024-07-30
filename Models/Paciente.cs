using System;
using System.Collections.Generic;

namespace FisioTerapias.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Cedula { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public virtual ICollection<Terapia> Terapia { get; set; } = new List<Terapia>();
}
