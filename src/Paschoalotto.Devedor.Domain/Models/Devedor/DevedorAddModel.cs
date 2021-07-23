using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Devedor.Domain.Models.Devedor
{
    public class DevedorAddModel
    {
        public int Id { get; set; }

        public int NumeroTitulo { get; set; }

        public string Nome { get; set; }

        public decimal Juros { get; set; }

        public decimal Multa { get; set; }

        public string CPF { get; set; }
    }
}
