using TrabalhoHerancaComposicaoVenda;

// Produto p1 = new Produto();
// p1.CadastrarProdutos();

// Produto p2 = new Produto();
// p2.CadastrarProdutos();

try
{
    Console.Clear();
    Especie e = new Especie(1500, 1501);

    e.ExibeDadosPagamento();

    Cheque c = new Cheque(1500, 1000001, DateTime.Parse("24/11/2024"), 1);
    c.ExibeDadosPagamento();

    Cartao ct = new Cartao(1500, "dados do fulano", 1);
    ct.ExibeDadosPagamento();

    Produto produto = new Produto();

    produto.CadastrarProdutos();
    produto.ExibeProduto();

    ItemVenda item = new ItemVenda(produto, 3, 15);
    item.ExibirItem();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

