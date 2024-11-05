using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AnswerOption
{
    public string Label { get; set; } = null!;

    public int AnswerId { get; set; }

    public string Text { get; set; } = null!;

    public bool IsChecked { get; set; }
}
