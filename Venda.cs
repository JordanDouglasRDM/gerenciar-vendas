using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Venda
    {
        public Mensagens mensagem;
        public long Codigo { get; set; }
        public bool StatusPagamento { get; set; }
        private static long AutoIncrementoCodigo { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; private set; }

        public List<ItemVenda> VetItemVenda { get; set; }
        public Pagamento Pagamento { get; set; }

        public Venda()
        {
            mensagem = new Mensagens();
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
        public Venda RegistrarVenda()
        {
            bool informarPagamento = true;
            while (informarPagamento)
            {
                mensagem.Primaria("\n\t##Pagar Venda##");
                Console.WriteLine("Formas de pagamento: ");
                Console.WriteLine("1 - Espécie");
                Console.WriteLine("2 - Cheque");
                Console.WriteLine("3 - Cartão");
                Console.Write("Selecione a opção desejada: ");
                string opcPagamento = Console.ReadLine();
                switch (opcPagamento)
                {
                    case "1":
                        try
                        {
                            Console.Clear();
                            mensagem.Primaria("\tPagamento em espécie selecionado.");
                            mensagem.Sucesso($"\nTotal da venda: {this.Total:C2}");
                            Especie especie = new Especie(this.Total);
                            especie.AdicionarPagamento();
                            mensagem.Sucesso($"\n\tQuantia recebida, o troco deve ser de {especie.Troco:C2}");
                            this.StatusPagamento = true;
                            mensagem.Sucesso($"\n\tPagamento finalizado com sucesso.");
                            this.AddPagamento(especie);
                            informarPagamento = false;

                        }
                        catch (Exception e)
                        {
                            mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.Clear();
                            mensagem.Primaria("\tPagamento em cheque selecionado.");
                            mensagem.Sucesso($"\nTotal da venda: {this.Total:C2}");
                            Cheque cheque = new Cheque(this.Total);
                            cheque.AdicionarPagamento();

                            mensagem.Sucesso($"\n\tQuantia recebida.");
                            this.StatusPagamento = true;
                            mensagem.Sucesso($"\n\tPagamento finalizado com sucesso.");
                            this.AddPagamento(cheque);
                            informarPagamento = false;
                        }
                        catch (Exception e)
                        {
                            mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                        }

                        break;
                    case "3":
                        try
                        {
                            Console.Clear();
                            mensagem.Primaria("\tPagamento em cartão selecionado.");
                            mensagem.Sucesso($"\nTotal da venda: {this.Total:C2}");
                            Cartao cartao = new Cartao(this.Total);
                            cartao.AdicionarPagamento();

                            mensagem.Sucesso($"\n\tQuantia recebida.");
                            this.StatusPagamento = true;
                            mensagem.Sucesso($"\n\tPagamento finalizado com sucesso.");
                            this.AddPagamento(cartao);
                            informarPagamento = false;
                        }
                        catch (Exception e)
                        {
                            mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                        }
                        break;

                    default:
                        mensagem.Erro("\n\tForma de pagamento inválida, tente novamente.");
                        break;
                }
            }
            return this;
        }
    }
}