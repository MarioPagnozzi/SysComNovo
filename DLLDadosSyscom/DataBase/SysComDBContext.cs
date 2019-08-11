using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DLLDadosSyscom.DataBase
{
    public class SysComDBContext : DbContext
    {
        public SysComDBContext(string conexao) : base(conexao)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
