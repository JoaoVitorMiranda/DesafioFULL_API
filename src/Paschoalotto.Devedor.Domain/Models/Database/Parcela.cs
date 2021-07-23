using Paschoalotto.Devedor.Infra.Common.DapperExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paschoalotto.Devedor.Domain.Models.Database
{
    [QueryTable("Parcela")]
    public partial class Parcela
    {
        [QueryField("Id")]
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [QueryField("DevedorId")]
        public int DevedorId { get; set; }

        [QueryField("Valor")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [QueryField("Vencimento")]
        [Column(TypeName = "datetime")]
        public DateTime Vencimento { get; set; }

        [ForeignKey(nameof(DevedorId))]
        [InverseProperty(nameof(Database.Devedor.Parcela))]
        public virtual Devedor Devedor { get; set; }
    }
}
