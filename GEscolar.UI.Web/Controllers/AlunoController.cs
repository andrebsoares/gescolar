using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class AlunoController : BaseController
    {

        private readonly AlunoAplicacao appAluno;

        public AlunoController()
        {
            appAluno = AlunoAplicacaoConstrutor.AlunoAplicacaoEF();
        }
        // GET: Aluno
        public ActionResult Index()
        {
            var listarTodos = appAluno.ListarTodos().OrderBy(x => x.ALU_IN_CODIGO);
            return View(listarTodos);
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalhesAlunoId = appAluno.ListarPorId(id.ToString());

            if (id == 0 || detalhesAlunoId == null)
            {
                ExibeMensagem('D', 52);

                return RedirectToAction("Index");
            }

            return View(detalhesAlunoId);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_aluno gesc_aluno)
        {
            if (ModelState.IsValid)
            {
                appAluno.Salvar(gesc_aluno);

                ExibeMensagem('S', 1);

                return RedirectToAction("Index");
            }

            return View(gesc_aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var ListaAlunoId = appAluno.ListarPorId(id.ToString());

            if (id == 0 || ListaAlunoId == null)
            {
                ExibeMensagem('D', 52);

                return RedirectToAction("Index");
            }

            return View(ListaAlunoId);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_aluno gesc_aluno)
        {
            if (ModelState.IsValid)
            {
                appAluno.Salvar(gesc_aluno);
                ExibeMensagem('S', 2);
                return RedirectToAction("Index");
            }

            return View(gesc_aluno);

        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteAlunoId = appAluno.ListarPorId(id.ToString());

            if (id == 0 || deleteAlunoId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }

            return View(deleteAlunoId);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteAluno = appAluno.ListarPorId(id.ToString());

                appAluno.Excluir(deleteAluno);
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_alunoturma_gesc_aluno_ALU_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 53);
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
