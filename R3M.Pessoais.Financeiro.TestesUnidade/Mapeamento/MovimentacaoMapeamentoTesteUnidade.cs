using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Dtos;
using R3M.Pessoais.Financeiro.Extensoes;

namespace R3M.Pessoais.Financeiro.TestesUnidade.Mapeamento;

public class MovimentacaoMapeamentoTesteUnidade
{
    private readonly IMapper _mapper;

    public MovimentacaoMapeamentoTesteUnidade()
    {
        var serviceCollections = new ServiceCollection();
        serviceCollections.RegistrarMapeadores();

        _mapper = serviceCollections.BuildServiceProvider().GetRequiredService<IMapper>();
    }

    [Fact]
    public void MovimentacaoRequest_Movimentacao_DeveMapear()
    {
        // Arrange
        var request = new MovimentacaoRequest
        {
            Data = new DateOnly(1987, 06, 11),
            Descricao = "Singela descrição",
            Valor = 37.3m
        };

        // Act
        var movimentacao = _mapper.Map<Movimentacao>(request);

        // Assert
        movimentacao.Data.Should().Be(request.Data);
        movimentacao.Descricao.Should().Be(request.Descricao);
        movimentacao.Valor.Should().Be(request.Valor);
    }

    [Fact]
    public void MovimentacaoRequest_Movimentacao_DeveMapearParaValoresPadrao()
    {
        // Arrange
        var request = new MovimentacaoRequest();

        // Act
        var movimentacao = _mapper.Map<Movimentacao>(request);

        // Assert
        movimentacao.Data.Should().Be(default);
        movimentacao.Descricao.Should().Be(request.Descricao);
        movimentacao.Valor.Should().Be(default);
    }

    //

    [Fact]
    public void Movimentacao_MovimentacaoResponse_DeveMapear()
    {
        // Arrange
        var movimentacao = new Movimentacao
        {
            Id = Guid.NewGuid(),
            DataInsercao = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Data = new DateOnly(1987, 06, 11),
            Descricao = "Singela descrição",
            Valor = 37.3m
        };

        // Act
        var response = _mapper.Map<MovimentacaoResponse>(movimentacao);

        // Assert
        response.Id.Should().Be(movimentacao.Id);            
        response.Data.Should().Be(movimentacao.Data);
        response.Descricao.Should().Be(movimentacao.Descricao);
        response.Valor.Should().Be(movimentacao.Valor);
    }

    [Fact]
    public void Movimentacao_MovimentacaoResponse_DeveMapearParaValoresPadrao()
    {
        // Arrange
        var movimentacao = new Movimentacao
        { 
            Descricao = string.Empty 
        };

        // Act
        var response = _mapper.Map<MovimentacaoResponse>(movimentacao);

        // Assert
        response.Id.Should().Be(movimentacao.Id);            
        response.Data.Should().Be(movimentacao.Data);
        response.Descricao.Should().Be(movimentacao.Descricao);
        response.Valor.Should().Be(movimentacao.Valor);
    }
}