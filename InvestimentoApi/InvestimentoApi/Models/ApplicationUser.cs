using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public Account Account { get; set; }
    }
}
