using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly ProfessorAplicacao appUsuario;

        public UsuarioController()
        {
            appUsuario = ProfessorAplicacaoConstrutor.ProfessorAplicacaoEF();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var listarTodos = appUsuario.ListarTodos().OrderBy(x => x.PRO_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesUsuarioId = appUsuario.ListarPorId(id.ToString());
            if (id == 0 || detalhesUsuarioId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(detalhesUsuarioId);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_professor gesc_professor)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Salvar(gesc_professor);
                ExibeMensagem('S', 1);

                return RedirectToAction("Index");
            }

            return View(gesc_professor);

        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaUsuarioId = appUsuario.ListarPorId(id.ToString());
            if (id == 0 || listaUsuarioId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(listaUsuarioId);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_professor gesc_professor)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Salvar(gesc_professor);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_professor);

        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteUsuarioId = appUsuario.ListarPorId(id.ToString());

            if (id == 0 || deleteUsuarioId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteUsuarioId);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteAluno = appUsuario.ListarPorId(id.ToString());

                appUsuario.Excluir(deleteAluno);

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                ExibeMensagem('D', 51);
            }
            return RedirectToAction("Index");
        }
    }
}
