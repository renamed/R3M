namespace R3M.Pessoais.Financeiro.Dominio;

public abstract class Registro
{
    public Guid Id { get; set; }

    public DateTime DataInsercao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
