using System;
using System.Collections.Generic;

namespace Exercicio10ASP.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DataRegisto { get; set; }

    public string? Pais { get; set; }
}
