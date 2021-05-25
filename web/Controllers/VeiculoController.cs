using System.Linq;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public ActionResult Index() {
			var veiculos = this.servico.listarOrdenado();
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
			var selectMarcas = new SelectList(marcas, "Id", "Nome");
			ViewBag.selectMarcas = selectMarcas;
		}
		public ActionResult Create() {
			this.CarregarDropMarca();

			return View();
		}

		// POST: VeiculoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				var id = collection["Id"];
				var Veiculo = new Veiculo {
					id = string.IsNullOrEmpty(id) ? 0 : int.Parse(id),
					cor = collection["Cor"],
					idMarca = int.Parse(collection["IdMarca"]),
					nome = collection["Nome"],
					placa = collection["Placa"]
				};

				this.servico.salvar(Veiculo);
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
