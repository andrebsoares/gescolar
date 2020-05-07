using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class FaltaRepositorioEF : IRepositorio<gesc_falta>
    {
        private readonly Contexto contexto;

        public FaltaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_falta entidade)
        {
            if (entidade.FAL_IN_CODIGO > 0)
            {
                var faltaAlterar = contexto.gesc_falta.FirstOrDefault(x => x.FAL_IN_CODIGO == entidade.FAL_IN_CODIGO);
                faltaAlterar.FAL_IN_QTDE = entidade.FAL_IN_QTDE;
                faltaAlterar.FAL_DT_DIA = entidade.FAL_DT_DIA; 
                faltaAlterar.ALT_IN_CODIGO= entidade.ALT_IN_CODIGO;
                faltaAlterar.DTU_IN_CODIGO = entidade.DTU_IN_CODIGO;
            }
            else
            {
                contexto.gesc_falta.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_falta entidade)
        {
            var cursoExcluir = contexto.gesc_falta.FirstOrDefault(x => x.FAL_IN_CODIGO == entidade.FAL_IN_CODIGO);
            contexto.Set<gesc_falta>().Remove(cursoExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_falta> ListarTodos()
        {
            return contexto.gesc_falta;
        }

        public gesc_falta ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_falta.FirstOrDefault(x => x.FAL_IN_CODIGO == idInt);
        }
    }
}
