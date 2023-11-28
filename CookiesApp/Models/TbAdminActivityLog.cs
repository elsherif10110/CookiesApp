using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbAdminActivityLog
{
    public int LogId { get; set; }

    public int? AdminId { get; set; }

    public DateTime? ActivityTime { get; set; }

    public string? ActivityDescription { get; set; }

    public virtual TbAdminUser? Admin { get; set; }
}
