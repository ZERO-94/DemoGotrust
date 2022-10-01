using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AccountUser
    {
        public string UserId { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? UserFullName { get; set; }
        public int? UserRole { get; set; }
    }
}
