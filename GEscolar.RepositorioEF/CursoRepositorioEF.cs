using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class CursoRepositorioEF : IRepositorio<gesc_curso>
    {
        private readonly Contexto contexto;

        public CursoRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_curso entidade)
        {
            if (entidade.CUR_IN_CODIGO > 0)
            {
                var cursoAlterar = contexto.gesc_curso.FirstOrDefault(x => x.CUR_IN_CODIGO == entidade.CUR_IN_CODIGO);
                cursoAlterar.CUR_ST_DESCRICAO = entidade.CUR_ST_DESCRICAO;
                cursoAlterar.CUR_IN_DURACAO = entidade.CUR_IN_DURACAO; ;
                cursoAlterar.CUR_CH_TIPO = entidade.CUR_CH_TIPO;
            }
            else
            {
                contexto.gesc_curso.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_curso entidade)
        {
            var cursoExcluir = contexto.gesc_curso.FirstOrDefault(x => x.CUR_IN_CODIGO == entidade.CUR_IN_CODIGO);
            contexto.Set<gesc_curso>().Remove(cursoExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_curso> ListarTodos()
        {
            return contexto.gesc_curso;
        }

        public gesc_curso ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_curso.FirstOrDefault(x => x.CUR_IN_CODIGO == idInt);
        }
    }
}
