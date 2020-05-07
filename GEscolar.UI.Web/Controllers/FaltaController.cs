using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class FaltaController : BaseController
    {

        private readonly FaltaAplicacao appFalta;

        public FaltaController()
        {
            appFalta = FaltaAplicacaoConstrutor.FaltaAplicacaoEF();
        }
        // GET: Falta
        public ActionResult Index()
        {
            var listarTodos = appFalta.ListarTodos().OrderBy(x => x.FAL_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Falta/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesFaltaId = appFalta.ListarPorId(id.ToString());
            if (id == 0 || detalhesFaltaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(detalhesFaltaId);
        }

        // GET: Falta/Create
        public ActionResult Create()
        {

            //var alunoTurma = AlunoTurmaAplicacaoConstrutor.AlunoTurmaAplicacaoEF().ListarTodos();
            //ViewBag.ALT_IN_CODIGO = new SelectList(alunoTurma, "ALT_IN_CODIGO", "AlunoTurmas.Alunos.ALU_ST_NOME");

            var disciplina = DisciplinaAplicacaoConstrutor.DisciplinaAplicacaoEF().ListarTodos();
            ViewBag.DIS_IN_CODIGO = new SelectList(disciplina, "DIS_IN_CODIGO", "DIS_ST_DESCRICAO");

            return View();
        }

        // POST: Falta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_falta gesc_falta)
        {
            if (ModelState.IsValid)
            {
                appFalta.Salvar(gesc_falta);
                ExibeMensagem('S', 1);
                return RedirectToAction("Index");
            }

            return View(gesc_falta);

        }

        // GET: Falta/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaFaltaId = appFalta.ListarPorId(id.ToString());

            if (id == 0 || listaFaltaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(listaFaltaId);
        }

        // POST: Falta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_falta gesc_falta)
        {
            if (ModelState.IsValid)
            {
                appFalta.Salvar(gesc_falta);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_falta);

        }

        // GET: Falta/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteFaltaId = appFalta.ListarPorId(id.ToString());

            if (id == 0 || deleteFaltaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteFaltaId);
        }

        // POST: Falta/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteFalta = appFalta.ListarPorId(id.ToString());
                appFalta.Excluir(deleteFalta);

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_falta_gesc_disciplinaturma_DTU_IN_CODIGO") > -1)
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
