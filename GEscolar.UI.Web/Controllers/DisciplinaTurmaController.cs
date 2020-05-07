using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class DisciplinaTurmaController : BaseController
    {
        private readonly DisciplinaTurmaAplicacao appDisciplinaTurma;

        public DisciplinaTurmaController()
        {
            appDisciplinaTurma = DisciplinaTurmaAplicacaoConstrutor.DisciplinaTurmaAplicacaoEF();
        }

        // GET: DisciplinaTurma
        public ActionResult Index()
        {
            var listarTodos = appDisciplinaTurma.ListarTodos().OrderBy(x => x.DTU_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: DisciplinaTurma/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesDisciplinaTurmaId = appDisciplinaTurma.ListarPorId(id.ToString());
            if (id == 0 || detalhesDisciplinaTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(detalhesDisciplinaTurmaId);
        }

        // GET: DisciplinaTurma/Create
        public ActionResult Create()
        {
            var Turma = TurmaAplicacaoConstrutor.TurmaAplicacaoEF().ListarTodos();
            ViewBag.TUR_IN_CODIGO = new SelectList(Turma, "TUR_IN_CODIGO", "TUR_ST_DESCRICAO");

            var disciplina = DisciplinaAplicacaoConstrutor.DisciplinaAplicacaoEF().ListarTodos();
            ViewBag.DIS_IN_CODIGO = new SelectList(disciplina, "DIS_IN_CODIGO", "DIS_ST_DESCRICAO");

            var usuario = ProfessorAplicacaoConstrutor.ProfessorAplicacaoEF().ListarTodos();
            ViewBag.PRO_IN_CODIGO = new SelectList(usuario, "PRO_IN_CODIGO", "PRO_ST_NOME");

            return View();
        }

        // POST: DisciplinaTurma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_disciplinaturma gesc_disciplinaturma)
        {
            if (ModelState.IsValid)
            {
                appDisciplinaTurma.Salvar(gesc_disciplinaturma);
                ExibeMensagem('S', 1);
                return RedirectToAction("Index");
            }

            return View(gesc_disciplinaturma);

        }

        // GET: DisciplinaTurma/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaDisciplinaTurmaId = appDisciplinaTurma.ListarPorId(id.ToString());

            if (id == 0 ||listaDisciplinaTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");                
            }
            var Turma = TurmaAplicacaoConstrutor.TurmaAplicacaoEF().ListarTodos();
            ViewBag.TUR_IN_CODIGO = new SelectList(Turma, "TUR_IN_CODIGO", "TUR_ST_DESCRICAO", listaDisciplinaTurmaId.TUR_IN_CODIGO);

            var disciplina = DisciplinaAplicacaoConstrutor.DisciplinaAplicacaoEF().ListarTodos();
            ViewBag.DIS_IN_CODIGO = new SelectList(disciplina, "DIS_IN_CODIGO", "DIS_ST_DESCRICAO", listaDisciplinaTurmaId.DIS_IN_CODIGO);

            var usuario = ProfessorAplicacaoConstrutor.ProfessorAplicacaoEF().ListarTodos();
            ViewBag.PRO_IN_CODIGO = new SelectList(usuario, "PRO_IN_CODIGO", "PRO_ST_NOME", listaDisciplinaTurmaId.PRO_IN_CODIGO);

            return View(listaDisciplinaTurmaId);
        }

        // POST: DisciplinaTurma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_disciplinaturma gesc_disciplinaturma)
        {
            if (ModelState.IsValid)
            {
                appDisciplinaTurma.Salvar(gesc_disciplinaturma);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_disciplinaturma);

        }

        // GET: DisciplinaTurma/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteDisciplinaTurmaId = appDisciplinaTurma.ListarPorId(id.ToString());
            if (id == 0 || deleteDisciplinaTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteDisciplinaTurmaId);
        }

        // POST: DisciplinaTurma/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteDisciplinaTurma = appDisciplinaTurma.ListarPorId(id.ToString());

                appDisciplinaTurma.Excluir(deleteDisciplinaTurma);
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_falta_gesc_disciplinaturma_DTU_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 56);
                }
                else if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_nota_gesc_disciplinaturma_DTU_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 57);
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
