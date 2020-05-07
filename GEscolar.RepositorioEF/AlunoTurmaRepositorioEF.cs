using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class AlunoTurmaRepositorioEF : IRepositorioAlunoTurma<gesc_alunoturma>
    {
        private readonly Contexto contexto;

        public AlunoTurmaRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_alunoturma entidade)
        {
            if (entidade.ALT_IN_CODIGO > 0)
            {
                var alunoAlterar = contexto.gesc_alunoturma.FirstOrDefault(x => x.ALT_IN_CODIGO == entidade.ALT_IN_CODIGO);
                alunoAlterar.ALU_IN_CODIGO = entidade.ALU_IN_CODIGO;
                alunoAlterar.TUR_IN_CODIGO = entidade.TUR_IN_CODIGO;
                alunoAlterar.ALT_CH_STATUS = entidade.ALT_CH_STATUS;
            }
            else
            {
                contexto.gesc_alunoturma.Add(entidade);
            }

            contexto.SaveChanges();

        }

        public void Excluir(gesc_alunoturma entidade)
        {
            var alunoTurmaExcluir = contexto.gesc_alunoturma.FirstOrDefault(x => x.ALT_IN_CODIGO == entidade.ALT_IN_CODIGO);
            contexto.Set<gesc_alunoturma>().Remove(alunoTurmaExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_alunoturma> ListarTodos()
        {
            return contexto.gesc_alunoturma;
        }

        public gesc_alunoturma ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_alunoturma.FirstOrDefault(x => x.ALT_IN_CODIGO == idInt);
        }

        public IEnumerable<gesc_alunoturma> ListaAlunosTurma(string codTurma)
        {
            int codInt;
            Int32.TryParse(codTurma, out codInt);
            return contexto.gesc_alunoturma.Where(x => x.TUR_IN_CODIGO == codInt).ToList();
        }
    }
}
