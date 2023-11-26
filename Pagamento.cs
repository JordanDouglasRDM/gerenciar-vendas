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
            this.Data = DateTime.Now;
            this.Total = total;
        }

        public virtual void ExibeDadosPagamento()
        {
            Console.WriteLine($"\nTotal Pagamento: {this.Total:C2}");
            Console.WriteLine($"Data e hora do pagamento: {this.Data}");
        }
    }
}