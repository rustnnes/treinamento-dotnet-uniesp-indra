using System.Collections.Generic;
using System.Linq;

namespace Backend {
	public class PaisRepositorio {

		private readonly FrotaContext context;
		public PaisRepositorio() {
			this.context = new FrotaContext();
		}

		public int atualizar(Pais pais) {
			this.context.Paises.Update(pais);
			return this.context.SaveChanges();
		}

		public void excluir(Pais pais) {
			this.context.Paises.Remove(pais);
			this.context.SaveChanges();
		}

		public Pais obter(int id) {
			return this.context.Paises.Find(id);
		}
		public IEnumerable<Pais> listarTodos() {
			return this.context.Paises.AsQueryable<Pais>();
		}

		public int cadastrar(Pais pais) {
			this.context.Add(pais);
			return this.context.SaveChanges();
		}
	}
}
