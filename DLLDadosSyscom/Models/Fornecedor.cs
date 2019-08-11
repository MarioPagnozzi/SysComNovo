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
    [Table("Fornecedores", Schema = "Cadastros")]
    public class Fornecedor : Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int FornecedorId { get; set; }

        [Display(Name = "Status")]
        [DefaultValue(0)]
        public Status status { get; set; }

        [Display(Name = "Categoria Fornecedor")]
        [Required(ErrorMessage = "Informe uma categoria")]
        public int categoriaFornecedor { get; set; }

        [NotMapped]
        public string strCategoriaFornecedor
        {
            get
            {
                var _categoria = "";

                switch(this.categoriaFornecedor)
                {
                    case 0:
                        _categoria = "Serviços";
                        break;
                    case 1:
                        _categoria = "Produtos";
                        break;
                    case 2:
                        _categoria = "Materiais";
                        break;
                    case 3:
                        _categoria = "Matéria Prima";
                        break;
                    case 4:
                        _categoria = "Indiferente";
                        break;
                }

                return _categoria;
            }
            set
            {
                if (value == "Serviços")
                {
                    this.categoriaFornecedor = 0;
                }
                if (value == "Produtos")
                {
                    this.categoriaFornecedor = 1;
                }
                if (value == "Materiais")
                {
                    this.categoriaFornecedor = 2;
                }
                if (value == "Matéria Prima")
                {
                    this.categoriaFornecedor = 3;
                }
                if (value == "Indiferente")
                {
                    this.categoriaFornecedor = 4;
                }
            }
        }

        public virtual Entidade entidade { get; set; }

        public Fornecedor()
        {
            entidade = new Entidade();
        }
    }
}
