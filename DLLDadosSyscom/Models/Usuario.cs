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
    [Table("Usuarios", Schema = "Cadastros")]
    public class Usuario : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int UsuarioId { get; set; }

        [Display(Name = "Nome Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Nome Usuário' deve ser informado")]
        [MaxLength(50)]
        public string nomeUsuario { get; set; }

        [Display(Name = "E-mail Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'E-mail Usuário' deve ser informado")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "informe um e-mail válido")]
        public string emailUsuario { get; set; }

        [Display(Name = "Senha Acesso")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Senha Acesso' deve ser informada")]
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)]
        [MinLength(8,ErrorMessage = "A senha deve possuir mais de 8 caracteres")]
        public string senhaUsuario { get; set; }

        public virtual ICollection<Grupo> grupos { get; set; }
        public virtual ICollection<Empresa> empresas { get; set; }
      

        public Usuario()
        {
            grupos = new List<Grupo>();
            empresas = new List<Empresa>();
        }
    }
}
