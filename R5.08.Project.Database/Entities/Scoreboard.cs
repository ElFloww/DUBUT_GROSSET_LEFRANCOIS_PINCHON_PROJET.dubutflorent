using System;
using System.Collections.Generic;

namespace R5._08.Project.Database.Entities;

public partial class Scoreboard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? NumberOfGames { get; set; }

    public int? NumberOfWins { get; set; }

    public int? AverageTime { get; set; }
}
