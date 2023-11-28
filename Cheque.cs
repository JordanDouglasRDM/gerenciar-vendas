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
        public Cheque(double total) : base(total)
        {
            
        }
        public Cheque AdicionarPagamento()
        {
            Console.Write("Informe o número do cheque: ");
            this.Numero = Convert.ToInt64(Console.ReadLine());

            Console.Write("Informe a data de deposito [dd/mm/aaaa]: ");
            this.DataDeposito = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe a situação [Qualquer número inteiro]: ");
            this.Situacao = Convert.ToInt32(Console.ReadLine());
            
            return this;
        }
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Número do cheque: {this.Numero} \tData de deposito: {this.DataDeposito} \tSituação do cheque: {this.Situacao}");
        }
    }
}