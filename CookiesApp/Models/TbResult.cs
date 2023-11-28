using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbResult
{
    public int ResultId { get; set; }

    public int? FormId { get; set; }

    public int? UserId { get; set; }

    public int? QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public DateTime? ResultDate { get; set; }

    public virtual TbAnswer? Answer { get; set; }

    public virtual TbForm? Form { get; set; }

    public virtual TbQuestion? Question { get; set; }

    public virtual TbUserAuthentication? User { get; set; }
}
