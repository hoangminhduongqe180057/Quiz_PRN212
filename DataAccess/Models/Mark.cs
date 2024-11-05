using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Mark
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int QuizId { get; set; }

    public decimal? Score { get; set; }

    public DateTime DateTaken { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
