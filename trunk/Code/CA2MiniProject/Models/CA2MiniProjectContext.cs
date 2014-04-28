using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2MiniProject.Models
{
    public class CA2MiniProjectContext :DbContext
    {
        public CA2MiniProjectContext(): base("name=CA2MiniProject")
        {
        }
        public System.Data.Entity.DbSet<CA2MiniProject.Models.User> Users { get; set; }
    }
}