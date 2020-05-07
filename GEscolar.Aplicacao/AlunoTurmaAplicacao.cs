using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class AlunoTurmaAplicacao
    {
        private readonly IRepositorioAlunoTurma<gesc_alunoturma> repositorio;

        public AlunoTurmaAplicacao(IRepositorioAlunoTurma<gesc_alunoturma> repo)
        {
            repositorio = repo;
        }

        public void Salvar(gesc_alunoturma alunoTurma)
        {
            repositorio.Salvar(alunoTurma);
        }

        public void Excluir(gesc_alunoturma alunoTurma)
        {
            repositorio.Excluir(alunoTurma);
        }

        public IEnumerable<gesc_alunoturma> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_alunoturma ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }

        public IEnumerable<gesc_alunoturma> ListaAlunosTurma(string codTurma)
        {
            return repositorio.ListaAlunosTurma(codTurma);
        }
    }
}
