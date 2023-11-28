using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbCommon
{
    public int? FormId { get; set; }

    public int? AnswerId { get; set; }

    public int? AnswerTypeId { get; set; }

    public int? QuestionId { get; set; }

    public virtual TbAnswer? Answer { get; set; }

    public virtual TbAnswerType? AnswerType { get; set; }

    public virtual TbForm? Form { get; set; }

    public virtual TbQuestion? Question { get; set; }
}
