using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using R3M.Pessoais.Financeiro.Aplicacao;
using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Dtos;

namespace R3M.Pessoais.Financeiro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimentacoesController : ControllerBase
{
    private readonly IMovimentacoesAplicacao _movimentacoesAplicacao;
    private readonly IMapper _mapper;
    private readonly IValidator<MovimentacaoRequest> _validator;

    public MovimentacoesController(IMovimentacoesAplicacao movimentacoesAplicacao, IMapper mapper, IValidator<MovimentacaoRequest> validator)
    {
        _movimentacoesAplicacao = movimentacoesAplicacao;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(MovimentacaoResponse), 201)]
    [ProducesResponseType(typeof(ErroResponse), 400)]        
    public async Task<IActionResult> CriarNovimentacao([FromBody] MovimentacaoRequest novaMovimentacao)
    {
        var resultadoValidadao = _validator.Validate(novaMovimentacao);
        if (!resultadoValidadao.IsValid) 
        {
            return BadRequest(CriarRespostaErro(resultadoValidadao));
        }

        var movimentacao = _mapper.Map<Movimentacao>(novaMovimentacao);
        await _movimentacoesAplicacao.CriarMovimentacaoAsync(movimentacao);

        var resposta = _mapper.Map<MovimentacaoResponse>(movimentacao);
        return Created(Request.Path, resposta);
    }

    private static IEnumerable<ErroResponse> CriarRespostaErro(ValidationResult resultadoValidadao)
    {
        return resultadoValidadao.Errors.Select(x => new ErroResponse
        {
            Mensagem = x.ErrorMessage
        });
    }
}
