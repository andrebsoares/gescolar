using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class ProfessorRepositorioEF : IRepositorio<gesc_professor>
    {
        private readonly Contexto contexto;

        public ProfessorRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_professor entidade)
        {
            if (entidade.PRO_IN_CODIGO > 0)
            {
                var usuarioAlterar = contexto.gesc_professor.FirstOrDefault(x => x.PRO_IN_CODIGO == entidade.PRO_IN_CODIGO);
                usuarioAlterar.PRO_ST_NOME = entidade.PRO_ST_NOME;
                usuarioAlterar.PRO_ST_CPF = entidade.PRO_ST_CPF;
                usuarioAlterar.PRO_ST_SENHA = entidade.PRO_ST_SENHA;
                usuarioAlterar.PRO_CH_TIPO = entidade.PRO_CH_TIPO;
                usuarioAlterar.PRO_ST_EMAIL = entidade.PRO_ST_EMAIL;

            }
            else
            {
                contexto.gesc_professor.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_professor entidade)
        {
            var profExcluir = contexto.gesc_professor.FirstOrDefault(x => x.PRO_IN_CODIGO == entidade.PRO_IN_CODIGO);
            contexto.Set<gesc_professor>().Remove(profExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_professor> ListarTodos()
        {
            return contexto.gesc_professor;
        }

        public gesc_professor ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_professor.FirstOrDefault(x => x.PRO_IN_CODIGO == idInt);
        }

    }
}
