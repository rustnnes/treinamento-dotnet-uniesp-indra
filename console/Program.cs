using System;
using System.Collections.Generic;
using System.Linq;
using Backend;

namespace TreinamentoApplication {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Bem Vindos ao Treinamento .NET");

			//criando uma lista de objetos que implementam a interface IVeiculo
			var listCarro = new List<Carro>();

			//instanciando um carro invocando o construtor default
			Carro veiculo = new Carro();

			//populando a lista...
			listCarro.Add(new Carro("verde", "fusca", 1));
			listCarro.Add(new Carro("azul", "fusca", 1));
			listCarro.Add(new Carro("azul", "vectra", 2));
			listCarro.Add(new Carro("branco", "gol", 1));
			//instanciando um objeto carro utilizando um inicializado de objetos
			//ao invés de invocar um construtor
			//listCarro.Add(new Carro
			//{
			//    Cor = "branco",
			//    Nome = "uno"
			//});

			//consulta LINQ no formato method query
			//Obs.: Atenção para a transformação que está sendo feita através do método Select()
			var listOrdenada = listCarro
													.OrderBy(x => x.Cor)
													.Select(carr => new Moto {
														Cor = carr.Cor,
														Nome = carr.Nome
													});

			//consulta LINQ no formato query based
			var listaOrdenada2 = from list in listCarro
													 orderby list.Cor
													 select new Moto {
														 Cor = list.Cor,
														 Nome = list.Nome
													 };

			//iterando sob a lista e imprimindo no console os valores das propriedades dos objetos.
			var carroRepositorio = new CarroRepositorio();
			// carroRepositorio.AddCarro(listCarro);
			// var carro = carroRepositorio.ObterPorId(11);
			// carro.Cor = "Preto";
			// carroRepositorio.Atualizar(carro);
			try {
				// carroRepositorio.AdicionarVarios(listCarro);
				var carros = carroRepositorio.ObterPorPaisOrigem("alemanha");
				foreach (var carro in carros) {
					Console.WriteLine($"{carro.Tipo}: {carro.Cor}");
					Console.WriteLine($"Nome: {carro.Nome}");
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}

			//foreach (var v in listCarro) {
			//  Console.WriteLine($"{v.Tipo}: {v.Cor}");
			//  Console.WriteLine($"Nome: {v.Nome}");
			//}

			Console.ReadKey();
		}
	}
}
