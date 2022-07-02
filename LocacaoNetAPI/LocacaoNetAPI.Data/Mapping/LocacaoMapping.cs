using LocacaoNetAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LocacaoNetAPI.Data.Mapping
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao");
            builder.HasOne(i => i.Cliente).WithMany().HasForeignKey(fk => fk.Id_Cliente);
            builder.HasOne(i => i.Filme).WithOne().HasForeignKey<Locacao>(fk => fk.Id_Filme);
        }
    }
}
