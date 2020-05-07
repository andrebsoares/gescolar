using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class TurmaAplicacao
    {
        private readonly IRepositorio<gesc_turma> repositorio;

        public TurmaAplicacao(IRepositorio<gesc_turma> repo)
        {
            repositorio = repo;
        }

        public void Salvar(gesc_turma turma)
        {
            repositorio.Salvar(turma);
        }

        public void Excluir(gesc_turma turma)
        {
            repositorio.Excluir(turma);
        }

        public IEnumerable<gesc_turma> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_turma ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
