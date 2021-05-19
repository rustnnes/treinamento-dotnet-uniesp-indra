using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinamentoWebApp.Servicos;

namespace TreinamentoWebApp.Controllers {
	public class PaisController : Controller {
		//private PaisRepositorio repositorio;
		private IPaisServico<Pais> servico;

		public PaisController(IPaisServico<Pais> servico) {
			this.servico = servico;
			//this.repositorio = new PaisRepositorio();
		}
		// GET: PaisController
		public ActionResult Index() {
			var paises = servico.ListarOrdenado();
			return View(paises);
		}

		// GET: PaisController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: PaisController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: PaisController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				var id = collection["Id"];
				var pais = new Pais {
					Id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					Nome = collection["Nome"].ToString().ToUpper()
				};

				this.servico.Salvar(pais);

				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: PaisController/Edit/5
		public ActionResult Edit(int id) {
			var pais = this.servico.Obter(id);
			return View("Create", pais);
		}

		// POST: PaisController/Edit/5
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

		// GET: PaisController/Delete/5
		public ActionResult Delete(int id) {
			this.servico.Excluir(id);
			return RedirectToAction("Index");
		}

		// POST: PaisController/Delete/5
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
