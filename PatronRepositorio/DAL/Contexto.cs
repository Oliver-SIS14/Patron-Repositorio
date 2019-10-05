using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }

        public Contexto() : base("ConStr") { }
    }
}
