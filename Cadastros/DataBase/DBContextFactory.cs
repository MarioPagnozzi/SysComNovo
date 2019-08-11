using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros.DataBase
{
    class DBContextFactory : IDbContextFactory<Cadastro_DBContext>
    {
        public Cadastro_DBContext Create()
        {
            var conexao = "Server=localhost,1433;Database=Dev_Syscom;user=sa,password=m4r101979;Integrated Security=True;";

            return new Cadastro_DBContext(conexao);
        }
    }
}
