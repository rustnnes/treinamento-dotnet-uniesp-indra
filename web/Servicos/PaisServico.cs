using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoWebApp.Servicos {
	public class PaisServico : IPaisServico<Pais> {
		private PaisRepositorio repositorio;
		public PaisServico() {
			this.repositorio = new PaisRepositorio();
		}

		public void excluir(int id) {
			var paisExcluir = this.repositorio.obter(id);
			if (paisExcluir != null)
				this.repositorio.excluir(paisExcluir);
		}

		public IEnumerable<Pais> listarOrdenado() {
			return this
				.repositorio
				.listarTodos()
				.OrderBy(x => x.nome)
				.ToList();
		}

		public Pais obter(int id) {
			return this.repositorio.obter(id);
		}

		public void salvar(Pais pais) {
			if (pais.id > 0)
				this.repositorio.atualizar(pais);
			else
				this.repositorio.cadastrar(pais);
		}
	}
}
