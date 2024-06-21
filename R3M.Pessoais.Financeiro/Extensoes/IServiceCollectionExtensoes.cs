using FluentValidation;

namespace R3M.Pessoais.Financeiro.Extensoes;

public static class IServiceCollectionExtensoes
{
    public static IServiceCollection RegistrarMapeadores(this IServiceCollection services)
        => services.AddAutoMapper(typeof(Program).Assembly);

    public static IServiceCollection RegistrarValidadores(this IServiceCollection services)
        => services.AddValidatorsFromAssembly(typeof(Program).Assembly);
}
