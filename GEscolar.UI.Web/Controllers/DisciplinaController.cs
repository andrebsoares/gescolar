using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class DisciplinaController : BaseController
    {

        private readonly DisciplinaAplicacao appDisciplina;

        public DisciplinaController()
        {
            appDisciplina = DisciplinaAplicacaoConstrutor.DisciplinaAplicacaoEF();
        }


        // GET: Disciplina
        public ActionResult Index()
        {
            var listaTodos = appDisciplina.ListarTodos().OrderBy(x => x.DIS_IN_CODIGO);
            return View(listaTodos);
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesDisciplinaId = appDisciplina.ListarPorId(id.ToString());
            if (id == 0 || detalhesDisciplinaId == null)
            {
                ExibeMensagem('D', 52);

                return RedirectToAction("Index");
            }
            return View(detalhesDisciplinaId);
        }

        // GET: Disciplina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_disciplina gesc_disciplina)
        {
            if (ModelState.IsValid)
            {
                appDisciplina.Salvar(gesc_disciplina);
                ExibeMensagem('S', 1);
                return RedirectToAction("Index");
            }

            return View(gesc_disciplina);

        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaDisciplinaId = appDisciplina.ListarPorId(id.ToString());
            if (id == 0 || listaDisciplinaId == null)
            {
                ExibeMensagem('D', 52);
            }
            return View(listaDisciplinaId);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_disciplina gesc_disciplina)
        {
            if (ModelState.IsValid)
            {
                appDisciplina.Salvar(gesc_disciplina);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_disciplina);
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteDisciplinaId = appDisciplina.ListarPorId(id.ToString());

            if (id == 0 || deleteDisciplinaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteDisciplinaId);
        }

        // POST: Disciplina/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteDisciplina = appDisciplina.ListarPorId(id.ToString());

                appDisciplina.Excluir(deleteDisciplina);
                ExibeMensagem('S', 3);
                return RedirectToAction("Index");

            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_disciplinaturma_gesc_disciplina_DIS_IN_CODIGO") > -1)
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
