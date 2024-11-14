using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        // IdentityUser already has what we need inside it 


        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}