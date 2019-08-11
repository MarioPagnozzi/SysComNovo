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
    [Table("Departamentos", Schema = "Cadastros")]
    public class Departamento : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int DepartamentoId { get; set; }

        [Display(Name = "Código Personalisado")]
        [MaxLength(5)]
        public string CodigoDepartamento { get; set; }

        [Display(Name = "Nome Departamento")]
        public string nomeDepartamento { get; set; }

        
        public virtual ICollection<Funcionario> funcionarios { get; set; }

        public Departamento()
        {
            funcionarios = new List<Funcionario>();
        }
    }
}
