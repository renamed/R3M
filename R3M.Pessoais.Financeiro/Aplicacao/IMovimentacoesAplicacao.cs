using R3M.Pessoais.Financeiro.Dominio;

namespace R3M.Pessoais.Financeiro.Aplicacao;

public interface IMovimentacoesAplicacao
{
    Task CriarMovimentacaoAsync(Movimentacao movimentacao);
}