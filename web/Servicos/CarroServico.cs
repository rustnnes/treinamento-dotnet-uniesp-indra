using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoWebApp.Servicos {
	public class CarroServico : ICarroServico<Carro> {
		private CarroRepositorio repositorio;
		public CarroServico() {
			this.repositorio = new CarroRepositorio();
		}
		public void Excluir(int id) {
			var carroExcluir = this.repositorio.ObterPorId(id);
			this.repositorio.Deletar(carroExcluir);
		}

		public IEnumerable<Carro> ListarOrdenado() {
			return this
				.repositorio
				.ObterTodos()
				.OrderBy(x => x.Nome)
				.ToList();
		}

		public Carro Obter(int id) {
			return this.repositorio.ObterPorId(id);
		}

		public void Salvar(Carro entidade) {
			if (entidade.Id > 0)
				this.repositorio.Atualizar(entidade);
			else
				this.repositorio.Adicionar(entidade);
		}
	}
}
