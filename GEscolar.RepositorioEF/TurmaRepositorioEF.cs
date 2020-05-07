using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class TurmaRepositorioEF :IRepositorio<gesc_turma>
    {
        private readonly Contexto contexto;

        public TurmaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_turma entidade)
        {
            if (entidade.TUR_IN_CODIGO > 0)
            {
                var turmaAlterar = contexto.gesc_turma.FirstOrDefault(x => x.TUR_IN_CODIGO == entidade.TUR_IN_CODIGO);
                turmaAlterar.TUR_ST_DESCRICAO = entidade.TUR_ST_DESCRICAO;
                turmaAlterar.TUR_CH_PERIODO = entidade.TUR_CH_PERIODO; ;
                turmaAlterar.CUR_IN_CODIGO = entidade.CUR_IN_CODIGO;
            }
            else
            {
                contexto.gesc_turma.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_turma entidade)
        {
            var turmaExcluir = contexto.gesc_turma.FirstOrDefault(x => x.TUR_IN_CODIGO == entidade.TUR_IN_CODIGO);
            contexto.Set<gesc_turma>().Remove(turmaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_turma> ListarTodos()
        {
            return contexto.gesc_turma;
        }

        public gesc_turma ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_turma.FirstOrDefault(x => x.TUR_IN_CODIGO == idInt);
        }
    }
}
