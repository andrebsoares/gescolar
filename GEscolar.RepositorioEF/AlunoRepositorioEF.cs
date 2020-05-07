using System;
using System.Collections.Generic;
using System.Linq;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.RepositorioEF
{
    public class AlunoRepositorioEF : IRepositorio<gesc_aluno>
    {
        private readonly Contexto contexto;

        public AlunoRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Salvar(gesc_aluno entidade)
        {
            if (entidade.ALU_IN_CODIGO > 0)
            {
                var alunoAlterar = contexto.gesc_aluno.FirstOrDefault(x => x.ALU_IN_CODIGO == entidade.ALU_IN_CODIGO);
                alunoAlterar.ALU_ST_NOME = entidade.ALU_ST_NOME;
                alunoAlterar.ALU_ST_CPF = entidade.ALU_ST_CPF;
                alunoAlterar.ALU_ST_SENHA = entidade.ALU_ST_SENHA;
                alunoAlterar.ALU_CH_STATUS = entidade.ALU_CH_STATUS;
            }
            else
            {
                contexto.gesc_aluno.Add(entidade);
            }
            contexto.SaveChanges();

        }

        public void Excluir(gesc_aluno entidade)
        {
            var alunoExcluir = contexto.gesc_aluno.FirstOrDefault(x => x.ALU_IN_CODIGO == entidade.ALU_IN_CODIGO);
            contexto.Set<gesc_aluno>().Remove(alunoExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<gesc_aluno> ListarTodos()
        {
            return contexto.gesc_aluno;
        }

        public gesc_aluno ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.gesc_aluno.FirstOrDefault(x => x.ALU_IN_CODIGO == idInt);
        }
    }
}
