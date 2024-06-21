using AutoMapper;
using R3M.Pessoais.Financeiro.Dominio;
using R3M.Pessoais.Financeiro.Dtos;

namespace R3M.Pessoais.Financeiro.Mapeamento;

public class MovimentacaoMapeamento : Profile
{
    public MovimentacaoMapeamento()
    {
        CreateMap<MovimentacaoRequest, Movimentacao>();
        CreateMap<Movimentacao, MovimentacaoResponse>();
    }
}
