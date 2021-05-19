using System.Linq;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreinamentoWebApp.Servicos;

namespace TreinamentoWebApp.Controllers {
	public class CarroController : Controller {
		private ICarroServico<Carro> servico;
		private MarcaRepositorio marcaRepositorio;
		public CarroController(ICarroServico<Carro> servico) {
			this.marcaRepositorio = new MarcaRepositorio();
			this.servico = servico;
		}
		// GET: CarroController
		public ActionResult Index() {
			var carros = this.servico.ListarOrdenado();
			return View(carros);
		}

		// GET: CarroController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: CarroController/Create

		private void CarregarDropMarca() {
			var marcas = this.marcaRepositorio.ObterTodos()
				.OrderBy(x => x.Nome)
				.ToList();
			var selectMarcas = new SelectList(marcas, "Id", "Nome");
			ViewBag.selectMarcas = selectMarcas;
		}
		public ActionResult Create() {
			this.CarregarDropMarca();

			return View();
		}

		// POST: CarroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				var id = collection["Id"];
				var carro = new Carro {
					Id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					Cor = collection["Cor"],
					IdMarca = int.Parse(collection["IdMarca"]),
					Nome = collection["Nome"],
					Placa = collection["Placa"]
				};

				this.servico.Salvar(carro);
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: CarroController/Edit/5
		public ActionResult Edit(int id) {
			var carroEdit = this.servico.Obter(id);
			this.CarregarDropMarca();
			return View("Create", carroEdit);
		}

		// POST: CarroController/Edit/5
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

		// GET: CarroController/Delete/5
		public ActionResult Delete(int id) {
			this.servico.Excluir(id);
			return RedirectToAction("Index");
		}

		// POST: CarroController/Delete/5
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
