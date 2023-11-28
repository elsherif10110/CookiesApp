using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbAnswer
{
    public int AnswerId { get; set; }

    public int? AnswerTypeId { get; set; }

    public virtual TbAnswerType? AnswerType { get; set; }

    public virtual ICollection<TbForm> TbForms { get; set; } = new List<TbForm>();

    public virtual ICollection<TbResult> TbResults { get; set; } = new List<TbResult>();
}
