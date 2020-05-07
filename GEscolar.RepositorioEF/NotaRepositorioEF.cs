using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class NotaRepositorioEF : IRepositorio<gesc_nota>
    {
        private readonly Contexto contexto;

        public NotaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_nota entidade)
        {
            if (entidade.NOT_IN_CODIGO > 0)
            {
                var notaAlterar = contexto.gesc_nota.FirstOrDefault(x => x.NOT_IN_CODIGO == entidade.NOT_IN_CODIGO);
                notaAlterar.NOT_DE_NOTA = entidade.NOT_DE_NOTA;
                notaAlterar.ALT_IN_CODIGO = entidade.ALT_IN_CODIGO;
                notaAlterar.DTU_IN_CODIGO = entidade.DTU_IN_CODIGO;
            }
            else
            {
                contexto.gesc_nota.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_nota entidade)
        {
            var notaExcluir = contexto.gesc_nota.FirstOrDefault(x => x.NOT_IN_CODIGO == entidade.NOT_IN_CODIGO);
            contexto.Set<gesc_nota>().Remove(notaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_nota> ListarTodos()
        {
            return contexto.gesc_nota;
        }

        public gesc_nota ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_nota.FirstOrDefault(x => x.NOT_IN_CODIGO == idInt);
        }
    }
}
