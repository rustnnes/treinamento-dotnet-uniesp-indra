using System;
using System.Collections.Generic;
using System.Linq;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TreinamentoWebApp.Servicos;

namespace TreinamentoWebApp.Controllers {
	public class VeiculoController : Controller {
		private IVeiculoServico<Veiculo> servico;
		private MarcaRepositorio marcaRepositorio;
		public VeiculoController(IVeiculoServico<Veiculo> servico) {
			this.marcaRepositorio = new MarcaRepositorio();
			this.servico = servico;
		}
		// GET: VeiculoController
		public ActionResult Index(string placa, string marca) {
			var veiculos = this.servico.listarOrdenado();
			if (!String.IsNullOrEmpty(placa))
				veiculos = veiculos.Where(
					v => v.placa.ToUpper()
											.Replace("-", "")
											.Contains(placa.ToUpper().Replace("-", ""))
				);
			if (!String.IsNullOrEmpty(marca))
				veiculos = veiculos.Where(
					v => v.marca.nome.ToUpper().Contains(marca.ToUpper())
				);
			return View(veiculos);
		}

		// GET: VeiculoController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: VeiculoController/Create

		private void CarregarDropMarca() {
			var marcas = this.marcaRepositorio.obterTodos()
				.OrderBy(x => x.nome)
				.ToList();
			var selectMarcas = new SelectList(marcas, "id", "nome");
			ViewBag.selectMarcas = selectMarcas;
		}
		private void loadDropType() {
			var types = new List<SelectListItem> {
				new SelectListItem { Text = "Carro", Selected = true },
				new SelectListItem { Text = "Moto" }
			};
			ViewBag.selectType = new SelectList(types, "Text", "Text");
		}
		public ActionResult Create() {
			this.CarregarDropMarca();
			this.loadDropType();

			return View();
		}

		// POST: VeiculoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				var id = collection["id"];
				var ano = collection["ano"];
				var veiculo = new Veiculo {
					id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					cor = collection["cor"],
					ano = string.IsNullOrEmpty(ano) ? 0 : int.Parse(ano),
					idMarca = int.Parse(collection["idMarca"]),
					nome = collection["nome"],
					placa = collection["placa"],
					tipo = collection["tipo"]
				};

				this.servico.salvar(veiculo);
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: VeiculoController/Edit/5
		public ActionResult Edit(int id) {
			var VeiculoEdit = this.servico.obter(id);
			this.CarregarDropMarca();
			this.loadDropType();
			return View("Create", VeiculoEdit);
		}

		// POST: VeiculoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: VeiculoController/Delete/5
		public ActionResult Delete(int id) {
			this.servico.excluir(id);
			return RedirectToAction("Index");
		}

		// POST: VeiculoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}
	}
}
