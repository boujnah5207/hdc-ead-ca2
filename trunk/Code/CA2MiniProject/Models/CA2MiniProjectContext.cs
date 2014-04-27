using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2MiniProject.Models
{
    public class CA2MiniProjectContext :DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}