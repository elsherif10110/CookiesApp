using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbQuestion
{
    public int QuestionId { get; set; }

    public string? QuestionText { get; set; }

    public int? CategoryId { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbForm> TbForms { get; set; } = new List<TbForm>();

    public virtual ICollection<TbResult> TbResults { get; set; } = new List<TbResult>();
}
