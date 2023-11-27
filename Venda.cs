using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Venda
    {
        public long Codigo { get; set; }
        public bool StatusPagamento { get; set; }
        private static long AutoIncrementoCodigo { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; private set; }

        public List<ItemVenda> VetItemVenda { get; set; }
        public Pagamento Pagamento { get; set; }

        public Venda()
        {
            VetItemVenda = new List<ItemVenda>();// aplica a composição de fato, pois só existe dentro do construtor
            this.Data = DateTime.Now;
            AutoIncrementoCodigo++;
            this.Codigo = AutoIncrementoCodigo;
        }
        public void CalculaTotal()
        {
            double soma = 0;
            foreach (ItemVenda itemVenda in VetItemVenda)
            {
                soma += itemVenda.Subtotal;
            }
            this.Total = soma;
        }
        public void AddItemVenda(ItemVenda itemVenda)
        {
            VetItemVenda.Add(itemVenda);
        }
        public void ExibirMeusItens()
        {
            foreach (ItemVenda item in VetItemVenda)
            {
                item.ExibirItem();
            }
        }

        public void AddPagamento(Pagamento pagamento)
        {
            this.Pagamento = pagamento;
        }
        public void ExibirVenda()
        {
            Console.WriteLine($"Código da Venda: {this.Codigo} \tData da Venda: {this.Data} \tTotal da Venda: {this.Total:C2} \tStatus do Pagamento: {(this.StatusPagamento == true ? "Pago" : "Em Aberto")}");
            if (this.StatusPagamento)
                Console.WriteLine($"Tipo de pagamento: {this.Pagamento.GetType().Name}");
        }
    }
}