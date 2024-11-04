using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int? CorrectAnswerId { get; set; }

    public int QuizId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Quiz Quiz { get; set; } = null!;
}
