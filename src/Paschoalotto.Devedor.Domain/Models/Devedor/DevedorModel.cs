using Paschoalotto.Devedor.Domain.Models.Parcela;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Devedor.Domain.Models.Devedor
{
    public class DevedorModel
    {
        public int Id { get; set; }

        public int NumeroTitulo { get; set; }

        public string Nome { get; set; }

        public decimal Juros { get; set; }

        public decimal Multa { get; set; }

        public string CPF { get; set; }

        public List<ParcelaModel> Parcela { get; set; }
    }
}
