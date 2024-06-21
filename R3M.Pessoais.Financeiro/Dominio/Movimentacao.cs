namespace R3M.Pessoais.Financeiro.Dominio;

public class Movimentacao : Registro
{
    public DateOnly Data { get; set; }
    public required string Descricao { get; set; }
    public decimal Valor { get; set; }
}
