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
    public abstract class Auditoria
    {
        //Bloco Auditoria
        [Display(Name = "Usuário Inclusão")]
        public string UsuarioInclusao { get; set; }

        [Display(Name = "Usuário Alteração")]
        public string UsuarioAlteracao { get; set; }

        [Display(Name = "Usuário Exclusão")]
        public string UsuarioExclusao { get; set; }

        [Display(Name = "Usuário Reativação")]
        public string UsuarioReativacao { get; set; }

        [Display(Name = "Data Inclusão")]
        [DefaultValue("getutcdate()")]
        public DateTime? DataInclusao { get; set; }

        [Display(Name = "Data Última Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Data Exclusão")]
        public DateTime? DataExclusao { get; set; }

        [Display(Name = "Data Reativação")]
        public DateTime? DataReativacao { get; set; }

        [NotMapped]
        public virtual bool check { get; set; }
    }
}
