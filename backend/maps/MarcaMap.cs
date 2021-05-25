using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Maps {
	public class MarcaMap : IEntityTypeConfiguration<Marca> {
		public void Configure(EntityTypeBuilder<Marca> builder) {
			builder.ToTable("Marca");
			builder.HasKey(x => x.id);

			builder
				.Property(x => x.id)
				.HasColumnName("id");

			builder
				.Property(x => x.idPais)
				.HasColumnName("IdPais")
				.IsRequired();

			builder
				.Property(x => x.nome)
				.HasColumnName("nome")
				.HasColumnType("varchar(50)")
				.IsRequired();

			builder
				.HasOne(x => x.pais)
				.WithMany()
				.HasForeignKey(x => x.idPais)
				.IsRequired();
		}
	}
}
