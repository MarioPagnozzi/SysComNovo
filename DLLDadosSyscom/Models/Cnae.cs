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
    [Table("Cnaes", Schema = "Cadastros")]
    public class Cnae
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int CnaeID { get; set; }

        [Display(Name = "Código CNAE")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Código CNAE' deve ser informado")]
        public string CodigoCNAE { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição' deve ser informada")]
        public string DescricaoCNAE { get; set; }

        public virtual ICollection<Empresa> empresas { get; set; }

        public Cnae()
        {
            empresas = new List<Empresa>();
        }
    }
}
