using Paschoalotto.Devedor.Infra.Common.DapperExtensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paschoalotto.Devedor.Domain.Models.Database
{
    [QueryTable("Devedor")]
    public partial class Devedor
    {
        public Devedor()
        {
            Parcela = new HashSet<Parcela>();
        }

        [QueryField("Id")]
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [QueryField("NumeroTitulo")]
        public int NumeroTitulo { get; set; }

        [QueryField("Nome")]
        [Required]
        [StringLength(250)]
        public string Nome { get; set; }

        [QueryField("Juros")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Juros { get; set; }

        [QueryField("Multa")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Multa { get; set; }

        [QueryField("CPF")]
        [Required]
        [Column("CPF")]
        [StringLength(11)]
        public string CPF { get; set; }

        [InverseProperty(nameof(Database.Parcela.Devedor))]
        public virtual ICollection<Parcela> Parcela { get; set; }
    }
}
