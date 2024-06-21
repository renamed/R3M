namespace R3M.Pessoais.Financeiro.Dtos;

public class MovimentacaoRequest
{
    public DateOnly? Data { get; set; }
    public string? Descricao { get; set; }
    public decimal? Valor { get; set; }
}
