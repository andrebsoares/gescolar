using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class CursoController : BaseController
    {
        private readonly CursoAplicacao appCurso;

        public CursoController()
        {
            appCurso = CursoAplicacaoConstrutor.CursoAplicacaoEF();
        }

        // GET: Curso
        public ActionResult Index()
        {
            var listarTodos = appCurso.ListarTodos().OrderBy(x => x.CUR_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesCursoId = appCurso.ListarPorId(id.ToString());

            if (id == 0 || detalhesCursoId == null)
            {
                ExibeMensagem('D', 52);

                return RedirectToAction("Index");
            }

            return View(detalhesCursoId);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_curso gesc_curso)
        {
            if (ModelState.IsValid)
            {
                appCurso.Salvar(gesc_curso);

                ExibeMensagem('S', 1);

                return RedirectToAction("Index");
            }

            return View(gesc_curso);

        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaCursoId = appCurso.ListarPorId(id.ToString());

            if (id == 0 || listaCursoId == null)
            {
                ExibeMensagem('D', 52);

                return RedirectToAction("Index");
            }


            return View(listaCursoId);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_curso gesc_curso)
        {
            if (ModelState.IsValid)
            {
                appCurso.Salvar(gesc_curso);
                ExibeMensagem('S', 2);

                return RedirectToAction("Index");
            }

            return View(gesc_curso);

        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteCursoId = appCurso.ListarPorId(id.ToString());

            if (id == 0 || deleteCursoId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteCursoId);
        }

        // POST: Curso/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCofirmed(int id)
        {
            try
            {
                var deleteCurso = appCurso.ListarPorId(id.ToString());

                appCurso.Excluir(deleteCurso);
                return RedirectToAction("Index");

            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_turma_gesc_curso_CUR_IN_CODIGO") > -1)
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
