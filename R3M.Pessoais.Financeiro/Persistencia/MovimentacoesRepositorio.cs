using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Persistencia.Contextos;
using System.Diagnostics.CodeAnalysis;

namespace R3M.Pessoais.Financeiro.Persistencia;

[ExcludeFromCodeCoverage]
public class MovimentacoesRepositorio : IMovimentacoesRepositorio
{
    private readonly FinanceiroContexto _financeiroContexto;

    public MovimentacoesRepositorio(FinanceiroContexto financeiroContexto)
    {
        _financeiroContexto = financeiroContexto;
    }

    public Task AdicionarAsync(Movimentacao movimentacao)
    {
        _financeiroContexto.Movimentacoes.Add(movimentacao);
        return _financeiroContexto.SaveChangesAsync();
    }
}
