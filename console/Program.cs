using System;
using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoApplication {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Bem Vindos ao Treinamento .NET");

			//criando uma lista de objetos que implementam a interface IVeiculo
			var listVeiculo = new List<Veiculo>();

			//instanciando um Veiculo invocando o construtor default
			// Veiculo veiculo = new Veiculo();

			//populando a lista...
			listVeiculo.Add(new Veiculo("verde", "fusca", 1, 2010, "Carro"));
			listVeiculo.Add(new Veiculo("azul", "fusca", 1, 2010, "Carro"));
			listVeiculo.Add(new Veiculo("azul", "vectra", 2, 2010, "Carro"));
			listVeiculo.Add(new Veiculo("branco", "gol", 1, 2010, "Carro"));
			//instanciando um objeto Veiculo utilizando um inicializado de objetos
			//ao invés de invocar um construtor
			//listVeiculo.Add(new Veiculo
			//{
			//    Cor = "branco",
			//    Nome = "uno"
			//});

			//consulta LINQ no formato method query
			//Obs.: Atenção para a transformação que está sendo feita através do método Select()
			var listOrdenada = listVeiculo
													.OrderBy(x => x.cor)
													.Select(carr => new Veiculo {
														cor = carr.cor,
														nome = carr.nome
													});

			//consulta LINQ no formato query based
			var listaOrdenada2 = from list in listVeiculo
													 orderby list.cor
													 select new Veiculo {
														 cor = list.cor,
														 nome = list.nome
													 };

			//iterando sob a lista e imprimindo no console os valores das propriedades dos objetos.
			var VeiculoRepositorio = new VeiculoRepositorio();
			// VeiculoRepositorio.AddVeiculo(listVeiculo);
			// var Veiculo = VeiculoRepositorio.ObterPorId(11);
			// Veiculo.Cor = "Preto";
			// VeiculoRepositorio.Atualizar(Veiculo);
			try {
				// VeiculoRepositorio.AdicionarVarios(listVeiculo);
				var veiculos = VeiculoRepositorio.obterPorPaisOrigem("alemanha");
				foreach (var veiculo in veiculos) {
					Console.WriteLine($"{veiculo.tipo}: {veiculo.cor}");
					Console.WriteLine($"Nome: {veiculo.nome}");
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}

			//foreach (var v in listVeiculo) {
			//  Console.WriteLine($"{v.Tipo}: {v.Cor}");
			//  Console.WriteLine($"Nome: {v.Nome}");
			//}

			Console.ReadKey();
		}
	}
}
