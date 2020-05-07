using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class NotaController : BaseController
    {
        private readonly NotaAplicacao appNota;

        public NotaController()
        {
            appNota = NotaAplicacaoConstrutor.NotaAplicacaoEF();
        }
        // GET: Nota
        public ActionResult Index()
        {
            var listarTodos = appNota.ListarTodos().OrderBy(x => x.NOT_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Nota/Details/5
        public ActionResult Details(int id = 0)
        {
            var listarNotaId = appNota.ListarPorId(id.ToString());

            if (id == 0 || listarNotaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(listarNotaId);
        }

        // GET: Nota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_nota gesc_nota)
        {
            if (ModelState.IsValid)
            {
                appNota.Salvar(gesc_nota);
                ExibeMensagem('S', 1);
                return RedirectToAction("Index");
            }

            return View(gesc_nota);

        }

        // GET: Nota/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaNotaId = appNota.ListarPorId(id.ToString());

            if (id == 0 || listaNotaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(listaNotaId);
        }

        // POST: Nota/Edit/5
        [HttpPost]
        public ActionResult Edit(gesc_nota gesc_nota)
        {
            if (ModelState.IsValid)
            {
                appNota.Salvar(gesc_nota);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_nota);

        }

        // GET: Nota/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteNotaId = appNota.ListarPorId(id.ToString());

            if (id == 0 || deleteNotaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }

            return View(deleteNotaId);
        }

        // POST: Nota/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteNota = appNota.ListarPorId(id.ToString());

                appNota.Excluir(deleteNota);
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_nota_gesc_disciplinaturma_DTU_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 51);
                }
                else
                {
                    ExibeMensagem('D', 51);
                }
                return RedirectToAction("Index");

            }

        }
    }
}
