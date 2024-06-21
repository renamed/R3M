using FakeItEasy;
using R3M.Pessoais.Financeiro.Aplicacao;
using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Persistencia;
using R3M.Pessoais.Financeiro.TestesUnidade.Builders;

namespace R3M.Pessoais.Financeiro.TestesUnidade.Aplicacao;

public class MovimentacoesAplicacaoTesteUnidade
{
    private readonly IMovimentacoesRepositorio _movimentacoesRepositorio;

    private readonly MovimentacoesAplicacao _movimentacaoAplicacao;

    public MovimentacoesAplicacaoTesteUnidade()
    {
        _movimentacoesRepositorio = A.Fake<IMovimentacoesRepositorio>();
        _movimentacaoAplicacao = new(_movimentacoesRepositorio);
    }

    [Fact]
    public async Task CriarMovimentacaoAsync_DeveChamarPersistencia()
    {
        // Arrange
        var movimentacao = MovimentacaoBuilder
                .Iniciar("Singela descrição")
                .Construir();

        // Act
        await _movimentacaoAplicacao.CriarMovimentacaoAsync(movimentacao);

        // Assert
        A.CallTo(() => _movimentacoesRepositorio.AdicionarAsync(movimentacao)).MustHaveHappenedOnceExactly();
    }
}