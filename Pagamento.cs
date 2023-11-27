using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Pagamento
    {
        protected DateTime Data { get; set; }
        protected double Total { get; set; }

        public Pagamento(double total)
        {
            this.Total = total;
            this.Data = DateTime.Now;
        }

        public virtual void ExibeDadosPagamento()
        {
            Console.WriteLine($"Total Pago: {this.Total:C2} \tData e hora do pagamento: {this.Data}");
        }
    }
}