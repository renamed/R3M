using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R3M.Pessoais.Financeiro.Dominio;
using System.Diagnostics.CodeAnalysis;

namespace R3M.Pessoais.Financeiro.Persistencia.Contextos;

[ExcludeFromCodeCoverage]
public class FinanceiroContexto : DbContext
{
    public DbSet<Movimentacao> Movimentacoes { get; set; }

    public FinanceiroContexto(DbContextOptions<FinanceiroContexto> opcoes) : base(opcoes) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigMovimentacoes(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigMovimentacoes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimentacao>(e =>
        {
            ConfigurarRegistro(e);

            e.Property(e => e.Data)
                .IsRequired();

            e.Property(e => e.Descricao)
                .HasMaxLength(Constantes.Tamanho.MaxTamMovimentacaoDescricao)
                .IsRequired();
                            
            e.HasIndex(x => x.Data).IsDescending();
        });
    }

    private static void ConfigurarRegistro<T>(EntityTypeBuilder<T> typeBuilder)
        where T : Registro
    {
        typeBuilder.HasIndex(e => e.Id);
        typeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
    }
}
