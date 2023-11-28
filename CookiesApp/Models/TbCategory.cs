using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<TbForm> TbForms { get; set; } = new List<TbForm>();

    public virtual ICollection<TbQuestion> TbQuestions { get; set; } = new List<TbQuestion>();
}
