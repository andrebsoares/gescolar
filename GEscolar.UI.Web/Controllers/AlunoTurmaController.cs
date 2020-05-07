using System.Linq;
using System.Web.Mvc;
using GEscolar.Aplicacao;
using GEscolar.Dominio;
using GEscolar.UI.Web.Utils;

namespace GEscolar.UI.Web.Controllers
{
    public class AlunoTurmaController : BaseController
    {
        private readonly AlunoTurmaAplicacao appAlunoTurma;

        public AlunoTurmaController()
        {
            appAlunoTurma = AlunoTurmaAplicacaoConstrutor.AlunoTurmaAplicacaoEF();
        }
        // GET: AlunoAplicacao
        public ActionResult Index(int codTurma = 0)
        {
            if (codTurma == 0)
            {
                var listarTodos = appAlunoTurma.ListarTodos().OrderBy(x => x.ALT_IN_CODIGO);
                return View(listarTodos);
            }
            else
            {
                var listarTurma = appAlunoTurma.ListaAlunosTurma(codTurma.ToString());
                return View(listarTurma);
            }

        }

        // GET: AlunoAplicacao/Details/5
        public ActionResult Details(int id = 0)
        {
            var detalheAlunoTurmaID = appAlunoTurma.ListarPorId(id.ToString());

            if (id == 0 || detalheAlunoTurmaID == null)
            {
                ExibeMensagem('D', 1);

                return RedirectToAction("Index");
            }

            return View(detalheAlunoTurmaID);
        }

        // GET: AlunoAplicacao/Create
        public ActionResult Create()
        {
            var turma = TurmaAplicacaoConstrutor.TurmaAplicacaoEF().ListarTodos();
            ViewBag.TUR_IN_CODIGO = new SelectList(turma, "TUR_IN_CODIGO", "TUR_ST_DESCRICAO");

            var aluno = AlunoAplicacaoConstrutor.AlunoAplicacaoEF().ListarTodos();
            ViewBag.ALU_IN_CODIGO = new SelectList(aluno, "ALU_IN_CODIGO", "ALU_ST_NOME");

            return View();
        }

        // POST: AlunoAplicacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(gesc_alunoturma gesc_alunoturma)
        {
            if (ModelState.IsValid)
            {
                appAlunoTurma.Salvar(gesc_alunoturma);

                ExibeMensagem('S', 1);

                return RedirectToAction("Index");
            }

            return View(gesc_alunoturma);

        }

        // GET: AlunoAplicacao/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var listaAlunoTurmaId = appAlunoTurma.ListarPorId(id.ToString());

            var aluno = AlunoAplicacaoConstrutor.AlunoAplicacaoEF().ListarTodos();
            ViewBag.ALU_IN_CODIGO = new SelectList(aluno, "ALU_IN_CODIGO", "ALU_ST_NOME", listaAlunoTurmaId.ALU_IN_CODIGO);

            var turma = TurmaAplicacaoConstrutor.TurmaAplicacaoEF().ListarTodos();
            ViewBag.TUR_IN_CODIGO = new SelectList(turma, "TUR_IN_CODIGO", "TUR_ST_DESCRICAO", listaAlunoTurmaId.TUR_IN_CODIGO);

            if (id == 0 || listaAlunoTurmaId == null)
            {
                ExibeMensagem('D', 1);

                return RedirectToAction("Index");
            }

            return View(listaAlunoTurmaId);
        }

        // POST: AlunoAplicacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(gesc_alunoturma gesc_alunoturma)
        {
            if (ModelState.IsValid)
            {
                appAlunoTurma.Salvar(gesc_alunoturma);

                ExibeMensagem('S', 2);

                return RedirectToAction("Index");
            }

            return View(gesc_alunoturma);

        }

        // GET: AlunoAplicacao/Delete/5
        public ActionResult Delete(int id = 0)
        {
            var deleteAlunoTurmaId = appAlunoTurma.ListarPorId(id.ToString());

            if (id == 0 || deleteAlunoTurmaId == null)
            {
                ExibeMensagem('D', 52);
                return RedirectToAction("Index");
            }
            return View(deleteAlunoTurmaId);
        }

        // POST: AlunoAplicacao/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteAlunoTurma = appAlunoTurma.ListarPorId(id.ToString());

                appAlunoTurma.Excluir(deleteAlunoTurma);
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_falta_gesc_alunoturma_ALT_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 54);
                }
                else if (e.InnerException.InnerException.Message.IndexOf("FK_gesc_nota_gesc_alunoturma_ALT_IN_CODIGO") > -1)
                {
                    ExibeMensagem('D', 55);
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
