using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend {
	public class CarroRepositorio : IRepositorio<Carro> {
		private FrotaContext context;

		public CarroRepositorio() {
			this.context = new FrotaContext();
		}

		public Carro ObterPorId(int id) {
			try {
				var carro = this.context.Carros.Find(id);
				if (carro != null) {
					return carro;
				}
				throw new Exception($"Nenhum registro localizado com o Id:{id}");
			}
			catch (Exception ex) {

				throw new Exception(ex.Message);
			}
		}

		public List<Carro> ObterPorNome(string nome) {
			try {
				var carros = this.context.Carros
						.Where(x => x.Nome.Equals(nome))
						.OrderBy(x => x.Nome);
				if (carros != null && carros.Any()) {
					return carros.ToList();
				}
				throw new Exception($"Nenhum carro localizado com o nome {nome}");
			}
			catch (Exception ex) {
				throw new Exception($"Failed to get: {ex.Message}");
			}
		}

		public List<Carro> ObterPorMarca(string marca) {
			try {
				var carros = this.context.Carros.Where(x => x.Marca.Nome.ToUpper().Equals(marca.ToUpper()));
				if (carros != null && carros.Any()) {
					return carros.ToList();
				}
				throw new Exception($"Nenhum veículo encontrado com a marca: {marca}");
			}
			catch {
				throw;
			}
		}

		public List<Carro> ObterPorPaisOrigem(string pais) {
			try {
				var carros = this.context.Carros
						.Where(x => x.Marca.Pais.Nome.ToUpper().Equals(pais.ToUpper()));
				if (carros != null && carros.Any()) {
					return carros.ToList();
				}
				throw new Exception($"Nenhum veículo encontrado com a marca: {pais}");
			}
			catch {
				throw;
			}
		}
		public List<Carro> ObterTodos() {
			return this.context.Carros.ToList();
		}

		public void Adicionar(Carro carro) {
			try {
				this.context.Carros.Add(carro);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao inserir um carro:{ex.Message}");
			}
		}

		public void AdicionarVarios(List<Carro> carros) {
			try {
				foreach (var carro in carros) {
					this.context.Carros.Add(carro);
				}
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao inserir um carro:{ex.Message}");
			}
		}

		public void Atualizar(Carro carro) {
			try {
				this.context.Update(carro);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao atualizar: {ex.Message}");
			}
		}

		public void Deletar(Carro carro) {
			try {
				this.context.Carros.Remove(carro);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao excluir: {ex.Message}");
			}
		}
	}
}
