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
    [Table("Beneficios", Schema = "Cadastros")]
    public class Benefios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int BeneficiosId { get; set; }

        [Display(Name = "Benefício")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Nome do Benefício' deve ser informado")]
        public string nomeBeneficio { get; set; }

        [Display(Name = "Valor Benefício")]
        [Required(ErrorMessage = "'Valor Benefício' deve ser informado")]
        [DataType(DataType.Currency)]
        public double valorBeneficio { get; set; }

        [Display(Name = "Incorpora Salário")]
        [DefaultValue(true)]
        public bool incorporaSalario { get; set; }

        [Display(Name = "Gera Descontos")]
        [DefaultValue(false)]
        public bool geraDescontos { get; set; }

        [Display(Name = "Calcula desconto sobre porcentagem")]
        [DefaultValue(false)]
        public bool calculaPorcentagem { get; set; }

        [Display(Name = "Valor Desconto")]
        public double valorDesconto { get; set; }

        
        public virtual ICollection<Funcionario> funcionarios { get; set; }

        public Benefios()
        {
            funcionarios = new List<Funcionario>();
        }
    }
}
