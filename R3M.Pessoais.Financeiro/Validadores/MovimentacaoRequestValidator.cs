using FluentValidation;
using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Dtos;

namespace R3M.Pessoais.Financeiro.Validadores;

public class MovimentacaoRequestValidator : AbstractValidator<MovimentacaoRequest>
{
    public MovimentacaoRequestValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage(Constantes.MensagensErro.CampoObrigatorio)
            .GreaterThan(DateOnly.MinValue)
            .LessThan(DateOnly.MaxValue)
            .WithMessage(Constantes.MensagensErro.CampoForaDoIntervalo);

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage(Constantes.MensagensErro.CampoObrigatorio)
            .MinimumLength(Constantes.Tamanho.MinTamMovimentacaoDescricao)
            .MaximumLength(Constantes.Tamanho.MaxTamMovimentacaoDescricao)
            .WithMessage(Constantes.MensagensErro.CampoForaDoTamanho);

        RuleFor(x => x.Valor)
            .NotEmpty()
            .WithMessage(Constantes.MensagensErro.CampoObrigatorio);
    }
}
