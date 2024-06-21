namespace R3M.Dominio.Comuns
{
    public abstract class Registro
    {
        public int Id { get; set; }

        public DateTime DataInsercao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}