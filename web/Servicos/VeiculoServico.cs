using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoWebApp.Servicos {
	public class VeiculoServico : IVeiculoServico<Veiculo> {
		private VeiculoRepositorio repositorio;
		public VeiculoServico() {
			this.repositorio = new VeiculoRepositorio();
		}
		public void excluir(int id) {
			var veiculoExcluir = this.repositorio.obterPorId(id);
			this.repositorio.deletar(veiculoExcluir);
		}

		public IEnumerable<Veiculo> listarOrdenado() {
			return this
				.repositorio
				.obterTodos()
				.OrderBy(x => x.nome)
				.ToList();
		}

		public Veiculo obter(int id) {
			return this.repositorio.obterPorId(id);
		}

		public void salvar(Veiculo entidade) {
			if (entidade.id > 0)
				this.repositorio.atualizar(entidade);
			else
				this.repositorio.adicionar(entidade);
		}
	}
}
