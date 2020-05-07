using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class DisciplinaRepositorioEF : IRepositorio<gesc_disciplina>
    {
        private readonly Contexto contexto;

        public DisciplinaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_disciplina entidade)
        {
            if (entidade.DIS_IN_CODIGO > 0)
            {
                var disciplinaAlterar = contexto.gesc_disciplina.FirstOrDefault(x => x.DIS_IN_CODIGO == entidade.DIS_IN_CODIGO);
                disciplinaAlterar.DIS_ST_DESCRICAO = entidade.DIS_ST_DESCRICAO;
            }
            else
            {
                contexto.gesc_disciplina.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_disciplina entidade)
        {
            var disciplinaExcluir = contexto.gesc_disciplina.FirstOrDefault(x => x.DIS_IN_CODIGO == entidade.DIS_IN_CODIGO);
            contexto.Set<gesc_disciplina>().Remove(disciplinaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_disciplina> ListarTodos()
        {
            return contexto.gesc_disciplina;
        }

        public gesc_disciplina ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_disciplina.FirstOrDefault(x => x.DIS_IN_CODIGO == idInt);
        }
    }
}
