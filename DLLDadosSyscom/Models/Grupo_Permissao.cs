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
    [Table("Grupos_Permissao", Schema = "Cadastros")]
    public class Grupo_Permissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int GrupoPermissaoId { get; set; }

        public virtual Tabela_Sistema tabela { get; set; }
        public virtual Grupo grupo { get; set; }

        [Display(Name = "Visualizar")]
        [DefaultValue(true)]
        public bool visualizar { get; set; }  

        [Display(Name = "Inserir")]
        [DefaultValue(true)]
        public bool inserir { get; set; }

        [Display(Name = "Alterar")]
        [DefaultValue(true)]
        public bool alterar { get; set; }

        [Display(Name = "Excluir")]
        [DefaultValue(true)]
        public bool excluir { get; set; }

        public Grupo_Permissao()
        {
            tabela = new Tabela_Sistema();
            grupo = new Grupo();
        }

    }
}
