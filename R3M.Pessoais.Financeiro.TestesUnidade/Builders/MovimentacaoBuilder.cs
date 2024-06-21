using R3M.Pessoais.Financeiro.Dominio;

namespace R3M.Pessoais.Financeiro.TestesUnidade.Builders;

public class MovimentacaoBuilder
{
    private Movimentacao _movimentacao;

    private MovimentacaoBuilder(string descricao) 
    {
        _movimentacao = new Movimentacao
        {
            Descricao = descricao
        };
    }

    public static MovimentacaoBuilder Iniciar(string descricao)
    {
        return new MovimentacaoBuilder(descricao);
    }


    public MovimentacaoBuilder AtribuirId(Guid id)
    {
        _movimentacao.Id = id;
        return this;
    }

    public MovimentacaoBuilder AtribuirDataInsercao(DateTime dataInsercao)
    {
        _movimentacao.DataInsercao = dataInsercao;
        return this;
    }

    public MovimentacaoBuilder AtribuirDataAtualizacao(DateTime? dataAtualizacao)
    {
        _movimentacao.DataAtualizacao = dataAtualizacao;
        return this;
    }

    public MovimentacaoBuilder AtribuirData(DateOnly data)
    {
        _movimentacao.Data = data;
        return this;
    }

    public MovimentacaoBuilder AtribuirValor(decimal valor)
    {
        _movimentacao.Valor = valor;
        return this;
    }

    public Movimentacao Construir()
        => _movimentacao;
}