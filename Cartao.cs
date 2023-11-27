using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Cartao : Pagamento
    {
        public string DadosTransacao { get; set; }
        public int ResultadoTransacao { get; set; }
        public Cartao(double total) : base(total)
        {
        }
    
        public Cartao AdicionarPagamento()
        {
            Console.Write("Informe a situação [Qualquer número inteiro]: ");
            this.ResultadoTransacao = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Informe os dados de transação [Qualquer string]: ");
            this.DadosTransacao = Console.ReadLine();

            return this;
        }
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Dados transação: {this.DadosTransacao} \tResultado da Transação: {this.ResultadoTransacao}");
        }
    }
}