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
    [Table("Funcionarios", Schema = "Cadastros")]
    public class Funcionario : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int FuncionarioId { get; set; }

        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "'Salario Base' deve ser informado")]
        [DataType(DataType.Currency)]
        public double SalarioBase { get; set; }

        [Display(Name = "Data Contratação")]
        public DateTime? dataContratacao { get; set; }

        [Display(Name = "Última Alteração Salarial")]
        public DateTime? dataUltimaAlteracaoSalario { get; set; }

        [Display(Name = "Segunda-Feira")]
        [DefaultValue(true)]
        public bool SegundaFeira { get; set; }

        [Display(Name = "Terça-Feira")]
        [DefaultValue(true)]
        public bool TercaFeira { get; set; }

        [Display(Name = "Quarta-Feira")]
        [DefaultValue(true)]
        public bool QuartaFeira { get; set; }

        [Display(Name = "Quinta-Feira")]
        [DefaultValue(true)]
        public bool QuintaFeira { get; set; }

        [Display(Name = "Sexta-Feira")]
        [DefaultValue(true)]
        public bool SextaFeira { get; set; }

        [Display(Name = "Sábado")]
        [DefaultValue(false)]
        public bool Sabados { get; set; }

        [Display(Name = "Domingo")]
        [DefaultValue(false)]
        public bool Domingos { get; set; }

        [Display(Name = "Possui Salubridade")]
        [DefaultValue(false)]
        public bool Salubridade { get; set; }

        [Display(Name = "Adicional Noturno")]
        [DefaultValue(false)]
        public bool AdicionalNoturno { get; set; }

        [Display(Name = "Calculo Adicional Noturno")]
        public double calcAdicionalNoturno { get; set; }

        [Display(Name = "Data Rescisão")]
        public DateTime? dataRescisao { get; set; }

        [Display(Name = "Data última Férias")]
        public DateTime? dataUltimaFerias { get; set; }

        [Display(Name = "Status")]
        [DefaultValue(0)]
        public int status { get; set; }

        [NotMapped]
        public virtual string strStatus
        {
            get
            {
                var _status = "";

                switch(this.status)
                {
                    case 0:
                        _status = "Ativo";
                        break;
                    case 1:
                        _status = "Exonerado";
                        break;
                    case 2:
                        _status = "Férias";
                        break;
                    case 3:
                        _status = "Licença Saúde";
                        break;
                    case 4:
                        _status = "Licença Maternidade";
                        break;
                    case 5:
                        _status = "Afastado";
                        break;
                    case 6:
                        _status = "Exonerado - Justa Causa";
                        break;
                }

                return _status;
            }
            set
            {
                if (value == "Ativo")
                {
                    this.status = 0;
                }
                if (value == "Exonerado")
                {
                    this.status = 1;
                }
                if (value == "Férias")
                {
                    this.status = 2;
                }
                if (value == "Licença Saúde")
                {
                    this.status = 3;
                }
                if (value == "Licença Maternidade")
                {
                    this.status = 4;
                }
                if (value == "Afastado")
                {
                    this.status = 5;
                }
                if (value == "Exonerado - Justa Causa")
                {
                    this.status = 6;
                }
            }
        }

        

        public virtual Entidade entidade { get; set; }
        public virtual Departamento departamento { get; set; }
        public virtual Tipo_Contratacao tipo_Contratacao { get; set; }
        public virtual ICollection<Benefios> beneficios { get; set; }

        
        public virtual Usuario usuario { get; set; }

        public Funcionario()
        {
            entidade = new Entidade();
            departamento = new Departamento();
            tipo_Contratacao = new Tipo_Contratacao();
            beneficios = new List<Benefios>();
            usuario = new Usuario();
        }
    }
}
