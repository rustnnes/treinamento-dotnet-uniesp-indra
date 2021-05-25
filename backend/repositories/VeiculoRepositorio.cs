using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend {
	public class VeiculoRepositorio : IRepositorio<Veiculo> {
		private FrotaContext context;

		public VeiculoRepositorio() {
			this.context = new FrotaContext();
		}

		public Veiculo obterPorId(int id) {
			try {
				var veiculo = this.context.Veiculos.Find(id);
				if (veiculo != null)
					return veiculo;
				throw new Exception($"Nenhum registro localizado com o Id:{id}");
			}
			catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}

		public List<Veiculo> obterPorNome(string nome) {
			try {
				var veiculos = this.context.Veiculos
						.Where(x => x.nome.Equals(nome))
						.OrderBy(x => x.nome);
				if (veiculos != null && veiculos.Any())
					return veiculos.ToList();
				throw new Exception($"Nenhum Veiculo localizado com o nome {nome}");
			}
			catch (Exception ex) {
				throw new Exception($"Failed to get: {ex.Message}");
			}
		}

		public List<Veiculo> obterPorMarca(string marca) {
			try {
				var veiculos = this.context.Veiculos.Where(x => x.marca.nome.ToUpper().Equals(marca.ToUpper()));
				if (veiculos != null && veiculos.Any())
					return veiculos.ToList();
				throw new Exception($"Nenhum veículo encontrado com a marca: {marca}");
			}
			catch {
				throw;
			}
		}

		public List<Veiculo> obterPorPaisOrigem(string pais) {
			try {
				var veiculos = this.context.Veiculos
						.Where(x => x.marca.pais.nome.ToUpper().Equals(pais.ToUpper()));
				if (veiculos != null && veiculos.Any())
					return veiculos.ToList();
				throw new Exception($"Nenhum veículo encontrado com a marca: {pais}");
			}
			catch {
				throw;
			}
		}
		public List<Veiculo> obterTodos() {
			return this.context.Veiculos.ToList();
		}

		public void adicionar(Veiculo Veiculo) {
			try {
				this.context.Veiculos.Add(Veiculo);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao inserir um Veiculo:{ex.Message}");
			}
		}

		public void adicionarVarios(List<Veiculo> veiculos) {
			try {
				foreach (var veiculo in veiculos)
					this.context.Veiculos.Add(veiculo);

				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao inserir um Veiculo:{ex.Message}");
			}
		}

		public void atualizar(Veiculo veiculo) {
			try {
				this.context.Update(veiculo);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao atualizar: {ex.Message}");
			}
		}

		public void deletar(Veiculo veiculo) {
			try {
				this.context.Veiculos.Remove(veiculo);
				this.context.SaveChanges();
			}
			catch (Exception ex) {
				throw new Exception($"Falha ao excluir: {ex.Message}");
			}
		}
	}
}
