using Microsoft.EntityFrameworkCore;

namespace Backend {
	public class FrotaContext : DbContext {

		public DbSet<Veiculo> Veiculos { get; set; }

		//ADICIONADO VIA REFLECTION NO DBCONTEXT
		public DbSet<Marca> Marcas { get; set; }
		public DbSet<Pais> Paises { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// https://www.learnentityframeworkcore.com/configuration/fluent-api
			// modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer(@"Server=localhost;Database=FrotaDB;User Id=sa;Password=Mudar123!");
		}
	}
}
