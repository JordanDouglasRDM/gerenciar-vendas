using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Venda
    {
        public DateTime Data { get; set; }
        private double total;

        public List<ItemVenda> VetItemVenda { get; set; }//define relacionamento de muitos itens de venda
        public List<Pagamento> VetPagamento { get; set; }//define relacionamento de muitos tipos de pagamentos para a mesma venda

        public Venda()
        {
            VetItemVenda = new List<ItemVenda>();// aplica a composição de fato, pois só existe dentro do construtor
            VetPagamento = new List<Pagamento>();// define a composição.
            this.Data = DateTime.Now;

        }
        public double Total
        {
            get
            {
                if (VetItemVenda != null)
                {
                    foreach (ItemVenda item in VetItemVenda)
                    {
                        Total += item.Subtotal;
                    }
                } else {
                    throw new Exception("Você não possui nenhum item de venda cadastrado.");
                }

                return Total;
            }
            set { total = value; }
        }
        public void AddItemVenda(ItemVenda itemVenda)
        {
            VetItemVenda.Add(itemVenda);
            Console.WriteLine("Item de venda adicionado com sucesso.");
        }
        public void ExibirVenda()
        {
            Console.WriteLine($"\nData da Venda: {this.Data}");
            Console.WriteLine($"Total da Venda: {this.Total}");
        }

        public void AddPagamento(Pagamento pagamento)
        {
            VetPagamento.Add(pagamento);
            Console.WriteLine("Pagamento adicionado com sucesso.");
        }

    }
}
/*
    1 - Façam os relacionamentos existirem na composição e com a classe pagamento;
    2 - Implemente os encapsulamentos;
    3 - Implemente o método 'Exibir()' de todas as classes;
    4 - Implementar todos os construtores com todos os parâmetros;
    5 - Instanciar objetos para testar;
    6 - O cheque pode ser predatado (pode usar today de datetime para pegar a data atual da venda)
    7 - menuzinho de venda para selecionar as opções

    1° Trabalho - 17/10/2023 -  Mensalista
    2° Trabalho - 24/10/2023 -  Gerenciador de bonificação
    3° Trabalho - 17/10/2023 -  
*/