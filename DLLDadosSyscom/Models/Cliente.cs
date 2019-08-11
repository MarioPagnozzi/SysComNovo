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
    [Table("Clientes", Schema = "Cadastros")]
    public class Cliente : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Status")]
        [DefaultValue(0)]
        public Status status { get; set; }

        [Display(Name = "Limite Crédito")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double limiteCredito { get; set; }

        [Display(Name = "Última Compra")]
        public DateTime? dataUltimaCompra { get; set; }

        [NotMapped]
        public virtual int DiasSemCompra
        {
            get
            {
                TimeSpan TotalDias;
                var _TotalDias = 0;

                if (this.dataUltimaCompra != null)
                {
                    TotalDias = DateTime.Now - (DateTime)this.dataUltimaCompra;
                    _TotalDias = (int)TotalDias.TotalDays;
                }

                return _TotalDias;
            }
        }

        [Display(Name = "Situação")]
        [DefaultValue(0)]
        public Situacao situacao { get; set; }

        [Display(Name = "Inadimplente Desde")]
        public DateTime? dataInadimplencia { get; set; }

        [NotMapped]
        public virtual int diasInadimplente
        {
            get {

                TimeSpan TotalDias;
                var _TotalDias = 0;

                if (this.dataInadimplencia != null)
                {
                    DateTime _dataInadimplencia = (DateTime)this.dataInadimplencia;
                    TotalDias = DateTime.Now - _dataInadimplencia;
                    _TotalDias = (int)TotalDias.TotalDays;
                }

                return _TotalDias;
            }
        }

        [Display(Name = "Valor Última Compra")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double ValorUltimaCompra { get; set; }

        public virtual Entidade entidade { get; set; }

        public Cliente()
        {
            entidade = new Entidade();
        }

    }
    public enum Situacao
    {
        Adimplente = 0,
        Inadimplente = 1
    }
}
