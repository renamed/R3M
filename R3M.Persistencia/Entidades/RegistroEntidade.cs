namespace R3M.Persistencia.Entidades
{
    public abstract class RegistroEntidade
    {
        public int Id { get; set; }

        public DateTime DataInsercao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}