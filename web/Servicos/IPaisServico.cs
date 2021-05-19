using System.Collections.Generic;

namespace TreinamentoWebApp.Servicos {
	public interface IPaisServico<T> {
		public void Salvar(T entidade);

		public IEnumerable<T> ListarOrdenado();

		public void Excluir(int id);

		public T Obter(int id);
	}
}
