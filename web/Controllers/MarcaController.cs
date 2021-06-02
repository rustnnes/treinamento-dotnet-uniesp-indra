using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TreinamentoWebApp.Controllers {
	public class MarcaController : Controller {
		private MarcaRepositorio repositorio;
		private PaisRepositorio repositorioPais;
		public MarcaController() {
			this.repositorio = new MarcaRepositorio();
			this.repositorioPais = new PaisRepositorio();
		}
		// GET: MarcaController
		public ActionResult Index() {
			var marcas = this.repositorio.obterTodos();
			return View(marcas);
		}

		// GET: MarcaController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		private void CarregarDropPais() {
			var paises = this.repositorioPais.listarTodos();
			var select = new SelectList(paises, "id", "nome");
			ViewBag.selectPaises = select;
		}

		// GET: MarcaController/Create
		public ActionResult Create() {
			this.CarregarDropPais();
			return View();
		}

		// POST: MarcaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				var id = collection["id"];
				var marca = new Marca {
					id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					nome = collection["nome"],
					idPais = int.Parse(collection["idPais"])
				};
				if (marca.id > 0) {
					this.repositorio.atualizar(marca);
				}
				else {
					this.repositorio.adicionar(marca);
				}
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: MarcaController/Edit/5
		public ActionResult Edit(int id) {
			var marca = this.repositorio.obterPorId(id);
			this.CarregarDropPais();
			return View("Create", marca);
		}

		// POST: MarcaController/Edit/5
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

		// GET: MarcaController/Delete/5
		public ActionResult Delete(int id) {
			var marcaExcluir = this.repositorio.obterPorId(id);
			this.repositorio.deletar(marcaExcluir);
			return RedirectToAction("Index");
		}

		// POST: MarcaController/Delete/5
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
