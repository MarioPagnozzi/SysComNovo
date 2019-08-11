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
    [Table("Empresas", Schema = "Cadastros")]
    public class Empresa : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpresaId { get; set; }
        [Display(Name = "Razão Social")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Razão Social' deve ser informada")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "'CNPJ' deve ser informado")]
        [Display(Name = "CNPJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "99.999.999/9999-99")]
        public string CNPJEmpresa { get; set; }
        [Display(Name = "Insc. Estadual")]
        public string IEEmpresa { get; set; }
        [Display(Name = "Inscrição Municipal")]
        public string IMEmpresa { get; set; }
        [Display(Name = "Inscrição SUFRAMA")]
        public string Suframa { get; set; }
        [Column(TypeName = "image")]
        [Display(Name = "Logo")]
        public byte[] LogoEmpresa { get; set; }
        [Display(Name = "Responsável Legal")]
        public string Responsavel { get; set; }
        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'E-mail' deve ser informado")]
        [EmailAddress(ErrorMessage = "'E-mail' informado não é válido")]
        public string EmailPrincipal { get; set; }
        [Display(Name = "Site")]
        public string SiteEmpresa { get; set; }
        [Display(Name = "Telefone Principal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Telefone Principal' deve ser informado")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(99) 9999-9999")]
        [MaxLength(13)]
        public string TelPrincipal { get; set; }
        [Display(Name = "Data de Abertura")]
        public DateTime? DataAbertura { get; set; }

        //Bloco Endereço
        [Display(Name = "Endereço Principal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Endereço Principal' deve ser inforado")]
        public string EnderecoPrincipal { get; set; }
        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Número' do endereço principal deve ser informado")]        
        public int NumeroEndPrincipal { get; set; }
        [Display(Name = "Quadra")]
        [MaxLength(2)]
        public string QuadraEndPrincipal { get; set; }

        [Display(Name = "CEP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'CEP' do endereço principal deve ser informado")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "99999-999")]
        [MaxLength(9)]
        public string CepEndPrincipal { get; set; }
        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Bairro' do endereço principal deve ser informado")]
        [MaxLength(100)]
        public string BairroEndPrincipal { get; set; }
        [Display(Name = "Complemento")]
        [MaxLength(100)]
        public string ComplementoEndPrincipal { get; set; }
        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Cidade' do endereço principal deve ser informada")]
        public string CidadeEndPrincipal { get; set; }
        [Display(Name = "UF")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "'UF' do endereço principal deve ser informada")]
        [MaxLength(2)]
        public string UFEndPrincipal { get; set; }

        //Bloco Ativ. Tributária
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Descrição CNAE Principal' deve ser informado")]
        [Display(Name = "Descrição CNAE Principal")]
        public string DescricaoCNAEPrincipal { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Código CNAE Principal' deve ser informado")]
        [Display(Name = "Código CNAE Principal")]
        public string CodigoCNAEPrincipal { get; set; }

        //Bloco Impostos e Tributos
        [Display(Name = "IRPJ (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal IRPJEmpresa { get; set; }
        [Display(Name = "PIS/PASEP (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal PISPASEPEmpresa { get; set; }
        [Display(Name = "CSLL (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal CSLLEmpresa { get; set; }
        [Display(Name = "COFINS (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal CofinsEmpresa { get; set; }
        [Display(Name = "INSS (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal INSSEmpresa { get; set; }
        [Display(Name = "ISS/ISSQN (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal ISSISSQNEmpresa { get; set; }
        [Display(Name = "Crédito ICMS (%)")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal CreditoICMS { get; set; }
        [Display(Name = "Sujeito ao IPI")]
        [DefaultValue(false)]
        public bool SujeitoIPI { get; set; }
        [Display(Name = "Emissão Nota Fiscal Modelo 1-A (Impressora Matricial)")]
        [DefaultValue(false)]
        public bool NFMatricial { get; set; }
        [Display(Name = "Emissão Nota Fiscal Eletrônica (NF-e")]
        [DefaultValue(false)]
        public bool NFE { get; set; }
        [Display(Name = "Emissão Nota Fiscal Eletrônica de Serviço (NFS-e")]
        [DefaultValue(false)]
        public bool NFSe { get; set; }
        [Display(Name = "PDV com emissão de NFC-e")]
        [DefaultValue(false)]
        public bool NFCe { get; set; }
        [Display(Name = "Incentivador Cultural")]
        [DefaultValue(false)]
        public bool IncentivadorCultural { get; set; }
        [Display(Name = "Empresa no Ramo da Construção Civil")]
        [DefaultValue(false)]
        public bool ConstrCivil { get; set; }

        [Display(Name = "CRT - Código de Regime Tributário")]
        public virtual Cad_CRT CRT { get; set; }

        [Display(Name = "Empresa Matriz")]
        [DefaultValue(true)]
        public bool Matriz { get; set; }

        [Display(Name = "CSOSN")]
        public virtual Cad_CSOSN Csosn { get; set; }

        [Display(Name = "PIS")]
        public virtual Cad_CST_PIS_Cofins Pis { get; set; }

        [Display(Name = "COFINS")]
        public virtual Cad_CST_PIS_Cofins Cofins { get; set; }

        [Display(Name = "IPI")]
        public virtual Cad_CST_IPI Ipi { get; set; }

        [Display(Name = "Natureza Jurídica")]
        public virtual Cad_Natureza_Juridica natureza_Juridica { get; set; }

        [Display(Name = "Filiais")]
        public virtual ICollection<Empresa> Filiais { get; set; }
        public virtual Empresa empresaMatriz { get; set; }

        [Display(Name = "Atividade Preponderante")]
        public virtual Cnae ativPreponderante { get; set; }

        [Display(Name = "Cnaes")]
        public virtual ICollection<Cnae> Cnaes { get; set; }

        [Display(Name = "Tributacao Especial NFS-e")]
        public virtual Cad_Trib_EspecNFSe tribEspecNFSe { get; set; }

        [Display(Name = "Limite Rentenção IRPJ")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RentencaoIRPJ { get; set; }

        [Display(Name = "Limite Rentenção PIS")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RentencaoPIS { get; set; }

        [Display(Name = "Limite Rentenção COFINS")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RentencaoCOFINS { get; set; }

        [Display(Name = "Limite Rentenção CSLL")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RentencaoCSLL { get; set; }

        [Display(Name = "Limite Rentenção INSS")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RentencaoINSS { get; set; }

        [Display(Name = "Status")]
        [DefaultValue(1)]
        public Status status { get; set; }

       
        public virtual ICollection<Endereco_Empresa> enderecosEmpresa { get; set; }
        public virtual ICollection<Tel_Empresa> telefonesEmpresa { get; set; }

        public virtual ICollection<Funcionario> funcionarios { get; set; }
        public virtual ICollection<Usuario> usuarios { get; set; }

        public Empresa()
        {
            CRT = new Cad_CRT();
            Csosn = new Cad_CSOSN();
            Pis = new Cad_CST_PIS_Cofins();
            Cofins = new Cad_CST_PIS_Cofins();
            Ipi = new Cad_CST_IPI();
            natureza_Juridica = new Cad_Natureza_Juridica();
            ativPreponderante = new Cnae();
            Cnaes = new List<Cnae>();
            tribEspecNFSe = new Cad_Trib_EspecNFSe();
            enderecosEmpresa = new List<Endereco_Empresa>();
            empresaMatriz = new Empresa();
            Filiais = new List<Empresa>();
            telefonesEmpresa = new List<Tel_Empresa>();
            funcionarios = new List<Funcionario>();
            usuarios = new List<Usuario>();
        }


        
    } 

    public enum Status
    {
        Inativo = 0,
        Ativo = 1,        
        Suspenso = 2,
        Excluído = 3
    }
}
