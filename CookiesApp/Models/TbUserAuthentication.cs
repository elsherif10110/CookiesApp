using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookiesApp.Models;

public partial class TbUserAuthentication
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username length should be between 3 and 50 characters")]
    public string? Username { get; set; }


    public byte[] PasswordHash { get; set; } = null!;
    [ValidateNever]

    public byte[] PasswordSalt { get; set; } = null!;
    [ValidateNever]

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? Birthdate { get; set; }
    [ValidateNever]

    public virtual ICollection<LoginLog> LoginLogs { get; set; } = new List<LoginLog>();

    public virtual ICollection<TbForm> TbForms { get; set; } = new List<TbForm>();

    public virtual ICollection<TbRegistrationLog> TbRegistrationLogs { get; set; } = new List<TbRegistrationLog>();

    public virtual ICollection<TbResult> TbResults { get; set; } = new List<TbResult>();
}
