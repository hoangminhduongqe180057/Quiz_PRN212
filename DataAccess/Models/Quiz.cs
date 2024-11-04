using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public TimeOnly? Duration { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
