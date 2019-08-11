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
    
    [Table("Entidades", Schema = "Cadastros")]
    public class Entidade : Auditoria
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int EntidadeID { get; set; }

        [Display(Name = "Tipo Pessoa")]
        [DefaultValue(0)]
        public int TipoPessoa { get; set; }

        [Display(Name = "Nome/Razão Social")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Nome/Razão Social' deve ser informado")]
        public string Nome_RazaoSocial { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string nomeMae { get; set; }

        [Display(Name = "Nome do Pai")]
        public string nomePai { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'CPF/CNPJ' deve ser informado")]
        [MaxLength(18)]        
        public string CPF_CNPJ { get; set; }

        [Display(Name = "RG/IE")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'RG/IE' deve ser informado")]
        [MaxLength(10)]
        public string RG_IE { get; set; }

        [Display(Name = "Endereço Principal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Endereço Principal' deve ser informado")]
        public string EnderecoPrincipal { get; set; } 

        [Display(Name = "Quadra")]
        [MaxLength(2)]
        public string Quadra { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "'Número' deve ser informado")]
        public int numero { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Bairro' deve ser informado")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(100)]
        public string Complemento { get; set; }

        [Display(Name = "UF")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'UF' deve ser informada")]
        [MaxLength(2)]
        public string Uf { get; set; }

        [Display(Name = "CEP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'CEP' deve ser informado")]
        [MaxLength(9)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "99999-999")]
        public string CEP { get; set; }

        [Display(Name = "Telefone Fixo")]
        [MaxLength(13)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(99) 9999-9999")]
        public string TelFixo { get; set; }

        [Display(Name = "Celular")]
        [MaxLength(14)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(99) 99999-9999")]
        public string celular { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Site")]
        public string site { get; set; }

        [Display(Name = "Facebook")]
        public string facebook { get; set; }

        [Display(Name = "Data Nasc./Abertura")]        
        public DateTime? data_nasc_Abertura { get; set; }

        [Display(Name = "Nome Fantasia/Social")]
        public string nome_fantasia_Social { get; set; }

        [Display(Name = "Genero Sexual")]
        [DefaultValue(0)]
        public int genero { get; set; }

        [Display(Name = "Profissão/Ativ. Financeira")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Profissão/Ativ. Financeira' deve ser informada")]
        public string profissaoAtivFinanceira { get; set; }

        [Display(Name = "Status")]
        [DefaultValue(0)]
        public Status status { get; set; }

        [NotMapped]
        public virtual string strGenero
        {
            get
            {
                var _genero = "";
                switch(this.genero)
                {
                    case 0:
                        _genero = "Masculino";
                        break;
                    case 1:
                        _genero = "Feminino";
                        break;
                    case 2:
                        _genero = "Trans. Masculino";
                        break;
                    case 3:
                        _genero = "Trans. Feminino";
                        break;                    
                }
                return _genero;
            }
            set
            {
                if (value == "Masculino")
                {
                    this.genero = 0;
                }
                if (value == "Feminino")
                {
                    this.genero = 1;
                }
                if (value == "Trans. Masculino")
                {
                    this.genero = 2;
                }
                if (value == "Trans. Feminino")
                {
                    this.genero = 3;
                }
            }
        }

        [NotMapped]
        public virtual string strTipoPessoa
        {
            get
            {
                var strPessoa = "";

                switch (this.TipoPessoa)
                {   
                    case 0:
                        strPessoa = "Física";
                        break;
                    case 1:
                        strPessoa = "Jurídica";
                        break;
                }
                return strPessoa;
            }

            set
            {
                if (value == "Física")
                {
                    this.TipoPessoa = 0;
                }
                else
                {
                    this.TipoPessoa = 1;
                }
            }
        }

        public virtual ICollection<Tel_Entidade> telefonesEntidade { get; set; }
        public virtual ICollection<Endereco_Entidade> EnderecosEntidade { get; set; }

        public virtual Fornecedor fornecedor { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Funcionario funcionario { get; set; }

        public Entidade()
        {
            
        }


    }
    
}
