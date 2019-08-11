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
    [Table("Grupos", Schema = "Cadastros")]
    public class Grupo : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int GrupoId { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição' do grupo deve ser informada")]
        public string descricaoGrupo { get; set; }

        public virtual ICollection<Usuario> usuarios { get; set; }
        public virtual Grupo_Permissao grupo_Permissao { get; set; }

        public Grupo()
        {
            usuarios = new List<Usuario>();
            grupo_Permissao = new Grupo_Permissao();
        }
    }
}
