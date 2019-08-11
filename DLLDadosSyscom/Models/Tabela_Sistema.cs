using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DLLDadosSyscom.Models
{
    [Table("Tabelas_Sistema", Schema = "Cadastros")]
    public class Tabela_Sistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int tabelaSistmaId { get; set; }

        [Display(Name = "Módulo")]
        public string moduloTabela { get; set; }
        [Display(Name = "Nome Tabela")]
        public string nomeTabela { get; set; }

        public virtual ICollection<Grupo_Permissao> grupos_Permissao { get; set; }
        public Tabela_Sistema()
        {
            grupos_Permissao = new List<Grupo_Permissao>();
        }
    }
}
