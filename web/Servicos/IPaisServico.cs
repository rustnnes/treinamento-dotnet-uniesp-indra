using System.Collections.Generic;

namespace TreinamentoWebApp.Servicos {
	public interface IPaisServico<T> {
		public void salvar(T entidade);

		public IEnumerable<T> listarOrdenado();

		public void excluir(int id);

		public T obter(int id);
	}
}
