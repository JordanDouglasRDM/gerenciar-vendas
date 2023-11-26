using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Cheque : Pagamento
    {
        public long Numero { get; set; }
        public DateTime DataDeposito { get; set; }
        public int Situacao { get; set; }
        public Cheque(double total, long numero, DateTime dataDep, int situacao) : base (total)
        {
            this.Numero = numero;
            this.DataDeposito = dataDep;
            this.Situacao = situacao;
        }
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Número do cheque: {this.Numero}");
            Console.WriteLine($"Data de deposito: {this.DataDeposito}");
            Console.WriteLine($"Situação do cheque: {this.Situacao}");
        }
    }
}