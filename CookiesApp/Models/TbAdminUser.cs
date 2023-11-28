using System;
using System.Collections.Generic;

namespace CookiesApp.Models;

public partial class TbAdminUser
{
    public int AdminId { get; set; }

    public string? Username { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TbAdminActivityLog> TbAdminActivityLogs { get; set; } = new List<TbAdminActivityLog>();

    public virtual ICollection<TbForm> TbForms { get; set; } = new List<TbForm>();
}
