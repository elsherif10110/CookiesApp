using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class LoginLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public bool? LoginSuccess { get; set; }

    public virtual TbUserAuthentication? User { get; set; }
}
