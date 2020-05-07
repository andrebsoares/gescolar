using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class DisciplinaTurmaRepositorioEF : IRepositorio<gesc_disciplinaturma>
    {
        private readonly Contexto contexto;

        public DisciplinaTurmaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_disciplinaturma entidade)
        {
            if (entidade.DTU_IN_CODIGO > 0)
            {
                var disciplinaTurmaAlterar = contexto.gesc_disciplinaturma.FirstOrDefault(x => x.DTU_IN_CODIGO == entidade.DTU_IN_CODIGO);
                disciplinaTurmaAlterar.DIS_IN_CODIGO = entidade.DIS_IN_CODIGO;
                disciplinaTurmaAlterar.TUR_IN_CODIGO = entidade.TUR_IN_CODIGO;
                disciplinaTurmaAlterar.PRO_IN_CODIGO = entidade.PRO_IN_CODIGO;


            }
            else
            {
                contexto.gesc_disciplinaturma.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_disciplinaturma entidade)
        {
            var disciplinaTurmaExcluir = contexto.gesc_disciplinaturma.FirstOrDefault(x => x.DTU_IN_CODIGO == entidade.DTU_IN_CODIGO);
            contexto.Set<gesc_disciplinaturma>().Remove(disciplinaTurmaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_disciplinaturma> ListarTodos()
        {
            return contexto.gesc_disciplinaturma;
        }

        public gesc_disciplinaturma ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_disciplinaturma.FirstOrDefault(x => x.DTU_IN_CODIGO == idInt);
        }
    }
}
