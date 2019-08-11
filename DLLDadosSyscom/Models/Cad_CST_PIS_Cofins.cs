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
    [Table("Tabela_PIS_Cofins", Schema = "Cadastros")]
    public class Cad_CST_PIS_Cofins
    {
        [Key]        
        [Display(Name = "Código")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Código' deve ser informado")]
        [MaxLength(3)]
        public string codigoCST { get; set; }
        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição' deve ser informada")]
        public string DescCSTPISCofins { get; set; }

        public virtual IEnumerable<Empresa> Empresas { get; set; }

        public Cad_CST_PIS_Cofins()
        {
            Empresas = new List<Empresa>();
        }

        
    }
}
