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
			var paises = servico.listarOrdenado();
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
					id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					nome = collection["Nome"].ToString().ToUpper()
				};

				this.servico.salvar(pais);

				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: PaisController/Edit/5
		public ActionResult Edit(int id) {
			var pais = this.servico.obter(id);
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
			this.servico.excluir(id);
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
