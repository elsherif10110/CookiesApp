using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbRegistrationLog
{
    public int RegistrationId { get; set; }

    public int? UserId { get; set; }

    public DateTime? RegistrationTime { get; set; }

    public bool? RegistrationSuccess { get; set; }

    public virtual TbUserAuthentication? User { get; set; }
}
