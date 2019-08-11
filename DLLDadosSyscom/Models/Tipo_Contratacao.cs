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
    [Table("Categoria_Contratacao", Schema = "Cadastros")]
    public class Tipo_Contratacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int TipoContratacaoId { get; set; }

        [Display(Name = "Descrição Contratação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descrição deve ser informada")]
        public string Descricacao { get; set; }
                
        public virtual ICollection<Funcionario> funcionarios { get; set; }
        
        public Tipo_Contratacao()
        {
            funcionarios = new List<Funcionario>();          
        }
    }
}
