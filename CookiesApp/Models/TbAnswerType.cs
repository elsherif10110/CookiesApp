using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbAnswerType
{
    public int AnswerTypeId { get; set; }

    public string? AnswerTypeName { get; set; }

    public virtual ICollection<TbAnswer> TbAnswers { get; set; } = new List<TbAnswer>();
}
