using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoWebApp.Servicos {
	public class PaisServico : IPaisServico<Pais> {
		private PaisRepositorio repositorio;
		public PaisServico() {
			this.repositorio = new PaisRepositorio();
		}

		public void Excluir(int id) {
			var paisExcluir = this.repositorio.Obter(id);
			if (paisExcluir != null) {
				this.repositorio.Excluir(paisExcluir);
			}
		}

		public IEnumerable<Pais> ListarOrdenado() {
			return this
				.repositorio
				.ListarTodos()
				.OrderBy(x => x.Nome)
				.ToList();
		}

		public Pais Obter(int id) {
			return this.repositorio.Obter(id);
		}

		public void Salvar(Pais pais) {
			if (pais.Id > 0)
				this.repositorio.Atualizar(pais);
			else
				this.repositorio.Cadastrar(pais);
		}
	}
}
