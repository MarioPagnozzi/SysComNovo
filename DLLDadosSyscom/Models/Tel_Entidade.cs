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
    [Table("Tels_Entidade", Schema = "Cadastros")]
    public class Tel_Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int TelEmpresaId { get; set; }

        [Display(Name = "Área (DDD)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Área deve ser informada")]
        [MaxLength(2)]
        public string codigoDDD { get; set; }

        [Display(Name = "Telefone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Telefone' deve ser informado")]
        [MaxLength(10)]
        public string numTelefone { get; set; }

        [Display(Name = "Operadora")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Operadora' deve ser informada")]
        public Operadora operadora { get; set; }

        [Display(Name = "Ramal")]
        public string Ramal { get; set; }

        [Display(Name = "Tipo")]
        public TipoTelefone tipoTelefone { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        public virtual Entidade entidade { get; set; }

        public Tel_Entidade()
        {
            entidade = new Entidade();
        }
    }
}
