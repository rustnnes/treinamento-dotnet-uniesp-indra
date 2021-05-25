using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend {
	public class MarcaRepositorio : IRepositorio<Marca> {
		private FrotaContext context;
		public MarcaRepositorio() {
			this.context = new FrotaContext();
		}
		public void adicionar(Marca entidade) {
			try {
				this.context.Set<Marca>().Add(entidade);
				this.context.SaveChanges();
			}
			catch (Exception ex) {

				throw new Exception($"Falha ao cadastrar: {ex.Message}");
			}
		}

		public void adicionarVarios(List<Marca> entidades) {
			throw new NotImplementedException();
		}

		public void atualizar(Marca entidade) {
			try {
				this.context.Set<Marca>().Update(entidade);
				this.context.SaveChanges();
			}
			catch (Exception ex) {

				throw new Exception($"Falha ao atualizar: {ex.Message}");
			}
		}

		public void deletar(Marca entidade) {
			try {
				this.context.Set<Marca>().Remove(entidade);
				this.context.SaveChanges();
			}
			catch (Exception ex) {

				throw new Exception($"Não foi possível excluir a marcar {entidade.nome}: {ex.Message}");
			}
		}

		public Marca obterPorId(int id) {
			return this.context.Set<Marca>().Find(id);
		}

		public List<Marca> obterPorNome(string nome) {
			throw new NotImplementedException();
		}

		public List<Marca> obterTodos() {
			return this.context.Set<Marca>().ToList();
		}
	}
}
