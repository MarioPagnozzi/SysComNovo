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
    [Table("Enderecos_Entidade", Schema = "Cadastros")]
    public class Endereco_Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int EnderecoEmpredaID { get; set; }

        [Display(Name = "Endereço")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Endereço' deve ser informado")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Número' deve ser informado")]
        public int Numero { get; set; }

        [Display(Name = "Quadra")]
        [MaxLength(2)]
        public string Quadra { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Bairro' deve ser informado")]
        public string Bairro { get; set; }

        [Display(Name = "CEP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'CEP' deve ser informado")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "99999-999")]
        public string CEP { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(100)]
        public string Complemento { get; set; }

        [Display(Name = "Tipo Endereço")]
        public TipoEndereco tipoEndereco { get; set; }

        [Display(Name = "Status")]
        public Status status { get; set; }

        public  virtual Entidade entidade { get; set; }

        public Endereco_Entidade()
        {
            entidade = new Entidade();
        }
    }
}
