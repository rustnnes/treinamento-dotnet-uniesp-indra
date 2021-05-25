using System.Collections.Generic;

namespace Backend {
	public interface IRepositorio<T> {
		public T obterPorId(int id);
		public List<T> obterPorNome(string nome);
		public List<T> obterTodos();
		public void adicionar(T entidade);
		public void adicionarVarios(List<T> entidades);
		public void atualizar(T entidade);
		public void deletar(T entidade);

	}
}
