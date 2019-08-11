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
    [Table("Tabela_Trib_EspecNFSe", Schema = "Cadastros")]
    public class Cad_Trib_EspecNFSe
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Código")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Código' deve ser informado")]      
        public int CodigoTributacao { get; set; }
        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição' deve ser informada")]
        public string DescTributacao { get; set; }

        public virtual IEnumerable<Empresa> Empresas { get; set; }

        public Cad_Trib_EspecNFSe()
        {
            Empresas = new List<Empresa>();
        }

        
    }
}
