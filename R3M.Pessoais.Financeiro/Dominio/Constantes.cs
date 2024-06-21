namespace R3M.Pessoais.Financeiro.Dominio;

public static class Constantes
{
    public static class MensagensErro
    {
        public const string CampoObrigatorio = "Campo {PropertyName} não foi informado";
        public const string CampoForaDoTamanho = "Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres. Atualmente tem {TotalLength}";
        public const string CampoForaDoIntervalo = "Campo {PropertyName} ser maior que {MinLength} e menor que {MaxLength}. Atualmente é {PropertyValue}";
    }

    public static class Tamanho
    {
        public const int MaxTamMovimentacaoDescricao = 75;
        public const int MinTamMovimentacaoDescricao = 5;
    }
}
