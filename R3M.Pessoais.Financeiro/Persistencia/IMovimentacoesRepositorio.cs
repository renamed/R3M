using R3M.Pessoais.Financeiro.Dominio;

namespace R3M.Pessoais.Financeiro.Persistencia;

public interface IMovimentacoesRepositorio
{
    Task AdicionarAsync(Movimentacao movimentacao);
}