using System.Linq.Expressions;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TrabalhoHerancaComposicaoVenda;
public class Program
{
    public static void Main(string[] args)
    {
        List<Produto> VetProdutos = new List<Produto>();
        List<Venda> VetVendas = new List<Venda>();
        Mensagens mensagem = new Mensagens();

        while (true)
        {
            bool statusProduto = VetProdutos.Count() > 0 ? true : false;
            bool statusVenda = VetVendas.Count() > 0 ? true : false;
            bool statusVendaEmAberto = false;

            foreach (Venda venda in VetVendas)
            {
                if (venda.StatusPagamento == false)
                {
                    statusVendaEmAberto = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Produto");
            mensagem.Sucesso($"\t1 - Adicionar um produto");
            mensagem.MensagemDinamica(statusProduto, $"\t2 - Listar produtos");
            mensagem.MensagemDinamica(statusProduto, $"\t3 - Remover um produto");

            Console.WriteLine("Venda");
            mensagem.MensagemDinamica(statusProduto, $"\t4 - Iniciar Nova Venda");
            mensagem.MensagemDinamica(statusVenda, $"\t5 - Listar Vendas");
            mensagem.MensagemDinamica(statusVenda, $"\t6 - Listar Vendas Detalhado");
            mensagem.MensagemDinamica(statusVenda, $"\t7 - Remover Venda");
            mensagem.MensagemDinamica(statusVendaEmAberto, $"\t8 - Pagar Vendas em aberto");

            Console.WriteLine("99 - Sair");
            Console.Write("\n\tEscolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {

                case "1":
                    try
                    {
                        Console.Clear();
                        mensagem.Primaria("\n\t###Adicionando Novo Produto###");
                        Produto novoP = new Produto();
                        novoP.AdicionarProduto();

                        VetProdutos.Add(novoP);

                        mensagem.Sucesso("\n\tProduto Adicionado com sucesso.");

                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "2":
                    try
                    {
                        if (statusProduto)
                        {
                            Console.Clear();
                            ListarProdutos(VetProdutos);
                        }
                        else
                        {
                            throw new Exception("Sem produtos cadastrados, adicione e tente novamente.");
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "3":
                    try
                    {
                        if (statusProduto)
                        {
                            Console.Clear();
                            bool statusExclusao = false;

                            ListarProdutos(VetProdutos);

                            Console.Write("\nQual o código do produto que deseja remover? ");
                            int codigoProd = Convert.ToInt32(Console.ReadLine());
                            foreach (Produto p in VetProdutos)
                            {
                                if (p.Codigo == codigoProd)
                                {
                                    VetProdutos.Remove(p);
                                    mensagem.Sucesso($"\n\tProduto '{p.Codigo}' removido com sucesso.");
                                    statusExclusao = true;
                                    break;
                                }
                            }
                            if (statusExclusao == false)
                                mensagem.Erro("\n\tProduto não encontrado.");
                        }
                        else
                        {
                            throw new Exception("Sem produtos cadastrados, adicione e tente novamente.");
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "4":
                    try
                    {
                        if (statusProduto)
                        {
                            Console.Clear();
                            bool ProdutoEncontrado = false;
                            bool desejaAdicionarItem = true;
                            Venda venda = new Venda();


                            while (desejaAdicionarItem)
                            {
                                Console.Clear();
                                mensagem.Primaria("\n\t###Nova Venda###");
                                Console.WriteLine("Adicione um Item a essa venda.");

                                mensagem.Primaria("\n\tLista de produtos");
                                ListarProdutos(VetProdutos);
                                Console.Write("Qual produto deseja vender? (código): ");
                                int codProd = Convert.ToInt32(Console.ReadLine());

                                ProdutoEncontrado = false;

                                foreach (Produto p in VetProdutos)
                                {
                                    if (p.Codigo == codProd)
                                    {
                                        ProdutoEncontrado = true;
                                        ItemVenda itemVenda = new ItemVenda(p);
                                        itemVenda.AdicionarItem();
                                        venda.AddItemVenda(itemVenda);
                                        mensagem.Sucesso("\n\tItem adicionado com sucesso.");
                                        break;
                                    }
                                }
                                if (!ProdutoEncontrado)
                                {
                                    mensagem.Erro("\n\tProduto não encontrado.");
                                }
                                Console.Write("Adicionar mais um item? [s/n]: ");
                                string adicionarItem = Console.ReadLine();

                                if (adicionarItem == "n")
                                {
                                    desejaAdicionarItem = false;
                                }
                            }
                            Console.Clear();

                            venda.ExibirMeusItens();
                            venda.CalculaTotal();
                            mensagem.Sucesso($"\nTotal da venda: {venda.Total:C2}");
                            Console.Write("\nDeseja realizar o pagamento agora? [s/n]: ");
                            string desejaPagarVenda = Console.ReadLine();

                            if (desejaPagarVenda == "s")
                            {
                                venda.RegistrarVenda();
                            }
                            else
                            {
                                venda.StatusPagamento = false;
                            }
                            VetVendas.Add(venda);
                        }
                        else
                        {
                            throw new Exception("Sem produtos cadastrados, adicione e tente novamente.");
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "5":
                    try
                    {
                        if (!statusVenda)
                        {
                            throw new Exception("Sem vendas registradas, adicione e tente novamente.");
                        }
                        Console.Clear();
                        mensagem.Rosa($"Quantidade de vendas: {VetVendas.Count()}");
                        foreach (Venda venda in VetVendas)
                        {
                            venda.ExibirVenda();
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "6":
                    try
                    {
                        if (!statusVenda)
                        {
                            throw new Exception("Sem vendas registradas, adicione e tente novamente.");
                        }
                        Console.Clear();
                        mensagem.Primaria("\t###Exibição de Vendas detalhada###");
                        mensagem.Amarelo($"\nQtde vendas: {VetVendas.Count()}");
                        foreach (Venda venda in VetVendas)
                        {
                            mensagem.Sucesso($"\nVenda ID ({venda.Codigo})");
                            venda.ExibirVenda();
                            mensagem.Rosa($"\nQtde itens: {venda.VetItemVenda.Count()}");
                            venda.ExibirMeusItens();
                            if (venda.Pagamento != null)
                            {
                                mensagem.Rosa($"\nPagamento da venda:");
                                venda.Pagamento.ExibeDadosPagamento();
                            }
                            mensagem.Rosa("\nProdutos da venda: ");
                            foreach (ItemVenda item in venda.VetItemVenda)
                            {
                                item.ObjProduto.ExibeProduto();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "7":
                    try
                    {
                        if (!statusVenda)
                        {
                            throw new Exception("Sem vendas registradas, adicione e tente novamente.");
                        }
                        Console.Clear();
                        mensagem.Primaria("\t###Remover Venda###");
                        foreach (Venda venda in VetVendas)
                        {
                            venda.ExibirVenda();
                        }
                        Console.Write("\nQual Venda deseja excluir? [código]: ");
                        int codVenda = Convert.ToInt32(Console.ReadLine());
                        bool vendaEncontrada = false;
                        foreach (Venda venda in VetVendas)
                        {
                            if (venda.Codigo == codVenda)
                            {
                                vendaEncontrada = true;
                                VetVendas.Remove(venda);
                                break;
                            }
                        }
                        if (!vendaEncontrada)
                        {
                            throw new Exception("Venda não encontrada. Tente novamente.");
                        }
                        mensagem.Sucesso("\n\tVenda removida com sucesso.");
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "8":
                    try
                    {
                        if (!statusVendaEmAberto)
                        {
                            throw new Exception("Você não possui vendas com pendências de pagamento.");
                        }
                        Console.Clear();
                        mensagem.Primaria("\n\t###Pagar vendas em aberto###");
                        foreach (Venda vend in VetVendas)
                        {
                            if (!vend.StatusPagamento)
                                vend.ExibirVenda();
                        }
                        Console.Write("Qual venda deseja pagar? [código]: ");
                        int codigoVenda = Convert.ToInt32(Console.ReadLine());

                        bool vendaEncontrada = false;
                        foreach (Venda venda in VetVendas)
                        {
                            if (venda.Codigo == codigoVenda)
                            {
                                vendaEncontrada = true;
                                mensagem.Sucesso($"\nTotal da venda: {venda.Total:C2}");
                                venda.RegistrarVenda();
                            }
                        }
                        if (!vendaEncontrada)
                        {
                            throw new Exception("Código da venda não encontrado. Tente novamente.");
                        }
                    }
                    catch (Exception e)
                    {
                        mensagem.Erro($"\n\tOops, ocorreu um erro: {e.Message}");
                    }

                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;

                case "99":
                    mensagem.Amarelo("\n\tSaindo do programa.");
                    Console.WriteLine("");
                    return;
                default:
                    mensagem.Erro("\n\tOpção inválida. Tente novamente.");
                    Console.WriteLine("");
                    mensagem.Secondaria("\n\tPressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public static void ListarProdutos(List<Produto> vet)
    {
        foreach (Produto p in vet)
        {
            p.ExibeProduto();
        }
    }
}