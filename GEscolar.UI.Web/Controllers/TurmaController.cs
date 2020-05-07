using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class TurmaController : BaseController
    {
        private readonly TurmaAplicacao appTurma;

        public TurmaController()
        {
            appTurma = TurmaAplicacaoConstrutor.TurmaAplicacaoEF();
        }

        // GET: Turma
        public ActionResult Index()
        {
            var listarTodos = appTurma.ListarTodos().OrderBy(x => x.TUR_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Turma/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalheTurmaId = appTurma.ListarPorId(id.ToString());
            if (id == 0 || detalheTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(detalheTurmaId);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            var cursos = CursoAplicacaoConstrutor.CursoAplicacaoEF().ListarTodos();
            ViewBag.CUR_IN_CODIGO = new SelectList(cursos, "CUR_IN_CODIGO", "CUR_ST_DESCRICAO");

            var disciplina = DisciplinaAplicacaoConstrutor.DisciplinaAplicacaoEF().ListarTodos();
            ViewBag.DIS_IN_CODIGO = new SelectList(disciplina, "DIS_IN_CODIGO", "DIS_ST_DESCRICAO");

            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_turma gesc_turma)
        {
            if (ModelState.IsValid)
            {
                appTurma.Salvar(gesc_turma);
                ExibeMensagem('S', 1);

                return RedirectToAction("Index");
            }

            return View(gesc_turma);

        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaTurmaId = appTurma.ListarPorId(id.ToString());
            if (id == 0 || listaTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            var cursos = CursoAplicacaoConstrutor.CursoAplicacaoEF().ListarTodos();
            ViewBag.CUR_IN_CODIGO = new SelectList(cursos, "CUR_IN_CODIGO", "CUR_ST_DESCRICAO", listaTurmaId.CUR_IN_CODIGO);

            return View(listaTurmaId);
        }

        // POST: Turma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_turma gesc_turma)
        {
            if (ModelState.IsValid)
            {
                appTurma.Salvar(gesc_turma);
                ExibeMensagem('S', 2);

                return RedirectToAction("Index");
            }

            return View(gesc_turma);

        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteTurmaId = appTurma.ListarPorId(id.ToString());

            if (id == 0 || deleteTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteTurmaId);
        }

        // POST: Turma/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCondirmed(int id)
        {
            try
            {
                var deleteCurso = appTurma.ListarPorId(id.ToString());

                appTurma.Excluir(deleteCurso);
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

            }
            return RedirectToAction("Index");
        }
    }
}
