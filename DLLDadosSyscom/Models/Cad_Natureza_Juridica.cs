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
    [Table("Tabela_Natureza_Juridica", Schema = "Cadastros")]
    public class Cad_Natureza_Juridica
    {
        [Key]        
        [Display(Name = "Código")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Código' deve ser informado")]
        [MaxLength(5)]
        public string codigoNTJuridica { get; set; }
        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição' deve ser informada")]
        public string descricaoNTJuridica { get; set; }
        [Display(Name = "Grupo")]
        [MaxLength(100)]
        public string grupoNTJuridica { get; set; }

        public virtual IEnumerable<Empresa> Empresas { get; set; }

        public Cad_Natureza_Juridica()
        {
            Empresas = new List<Empresa>();
        }

        
    }
}
