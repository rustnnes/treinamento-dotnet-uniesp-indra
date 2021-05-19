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
			var marcas = this.repositorio.ObterTodos();
			return View(marcas);
		}

		// GET: MarcaController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		private void CarregarDropPais() {
			var paises = this.repositorioPais.ListarTodos();
			var select = new SelectList(paises, "Id", "Nome");
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
				var id = collection["Id"];
				var marca = new Marca {
					Id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					Nome = collection["Nome"],
					IdPais = int.Parse(collection["IdPais"])
				};
				if (marca.Id > 0) {
					this.repositorio.Atualizar(marca);
				}
				else {
					this.repositorio.Adicionar(marca);
				}
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: MarcaController/Edit/5
		public ActionResult Edit(int id) {
			var marca = this.repositorio.ObterPorId(id);
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
			var marcaExcluir = this.repositorio.ObterPorId(id);
			this.repositorio.Deletar(marcaExcluir);
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
