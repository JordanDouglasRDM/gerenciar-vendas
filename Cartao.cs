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
        public Cartao(double total, string dadosTrans, int resultTrans) : base (total)
        {
            this.DadosTransacao = dadosTrans;
            this.ResultadoTransacao = resultTrans;
        }
        
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Dados transação: {this.DadosTransacao}");
            Console.WriteLine($"Resultado da Transacao: {this.ResultadoTransacao}");
        }
    }
}