using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePlan.Darlan.Models;

namespace TestePlan.Darlan.DAL
{
    public class Context : DbContext
    {
        public Context() : base("EFConnectionString")
        {

        }
        public DbSet<Cliente>Clientes { get; set; }
    }


}