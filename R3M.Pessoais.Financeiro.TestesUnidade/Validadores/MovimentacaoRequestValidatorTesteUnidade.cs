using FluentValidation.TestHelper;
using R3M.Pessoais.Financeiro.Dtos;
using R3M.Pessoais.Financeiro.Validadores;

namespace R3M.Pessoais.Financeiro.TestesUnidade.Validadores;

public class MovimentacaoRequestValidatorTesteUnidade
{
    [Theory, MemberData(nameof(ListarValorPadraoParaDatas))]
    public void Data_NaoPodeSerDefault(DateOnly? valorData)
    {
        // Arrange
        var request = new MovimentacaoRequest
        {
            Data = valorData
        };
        var movimentacaoRequestValidator = new MovimentacaoRequestValidator();

        // Act
        var result = movimentacaoRequestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Data);
    }
    

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abcd")] // 4 caracteres
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] // 76 caracteres
    public void Descricao_NaoPodeSerInvalido(string valorDescricao)
    {
        // Arrange
        var request = new MovimentacaoRequest
        {
            Data = DateOnly.FromDateTime(DateTime.Now),
            Descricao = valorDescricao
        };
        var movimentacaoRequestValidator = new MovimentacaoRequestValidator();

        // Act
        var result = movimentacaoRequestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Descricao);
    }

    [Fact]
    public void Valor_NaoPodeSerInvalido()
    {
        // Arrange
        var request = new MovimentacaoRequest
        {
            Data = DateOnly.FromDateTime(DateTime.Now),
            Descricao = "Descrição abstrata"
        };
        var movimentacaoRequestValidator = new MovimentacaoRequestValidator();

        // Act
        var result = movimentacaoRequestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Valor);
    }

    [Fact]
    public void NaoPodeTerErro()
    {
        // Arrange
        var request = new MovimentacaoRequest
        {
            Data = DateOnly.FromDateTime(DateTime.Now),
            Descricao = "Descrição abstrata",
            Valor = 0
        };
        var movimentacaoRequestValidator = new MovimentacaoRequestValidator();

        // Act
        var result = movimentacaoRequestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    public static IEnumerable<object?[]> ListarValorPadraoParaDatas =>
        [
            [ DateOnly.MinValue ],
            [ DateOnly.MaxValue ],
            [ null ]
        ];
}