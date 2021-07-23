using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Devedor.Domain.Models.Parcela
{
    public class ParcelaAddModel
    {
        public int Id { get; set; }

        public int DevedorId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Vencimento { get; set; }
    }
}
