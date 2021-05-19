using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Maps {
	public class MarcaMap : IEntityTypeConfiguration<Marca> {
		public void Configure(EntityTypeBuilder<Marca> builder) {
			builder.ToTable("Marca");
			builder.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("Id");

			builder
				.Property(x => x.IdPais)
				.HasColumnName("IdPais")
				.IsRequired();

			builder
				.Property(x => x.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(50)")
				.IsRequired();

			builder
				.HasOne(x => x.Pais)
				.WithMany()
				.HasForeignKey(x => x.IdPais)
				.IsRequired();
		}
	}
}
