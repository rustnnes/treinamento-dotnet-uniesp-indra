using System.Collections.Generic;

namespace TreinamentoWebApp.Servicos {
	public interface IVeiculoServico<T> {
		public void salvar(T entidade);

		public IEnumerable<T> listarOrdenado();

		public void excluir(int id);

		public T obter(int id);
	}
}
