namespace R3M.Pessoais.Financeiro.Dtos;

public class MovimentacaoResponse
{
    public Guid Id { get; set; }
    public DateOnly? Data { get; set; }
    public required string Descricao { get; init; }
    public decimal Valor { get; init; }
}
