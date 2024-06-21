using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Persistencia;

namespace R3M.Pessoais.Financeiro.Aplicacao;

public class MovimentacoesAplicacao : IMovimentacoesAplicacao
{
    private readonly IMovimentacoesRepositorio _movimentacoesRepositorio;

    public MovimentacoesAplicacao(IMovimentacoesRepositorio movimentacoesRepositorio)
    {
        _movimentacoesRepositorio = movimentacoesRepositorio;
    }

    public Task CriarMovimentacaoAsync(Movimentacao movimentacao)
    {
        return _movimentacoesRepositorio.AdicionarAsync(movimentacao);
    }
}
