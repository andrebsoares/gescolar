using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class DisciplinaTurmaAplicacao
    {
        private readonly IRepositorio<gesc_disciplinaturma> repositorio;

        public DisciplinaTurmaAplicacao(IRepositorio<gesc_disciplinaturma> repo )
        {
            repositorio = repo;
        }

        public void Salvar(gesc_disciplinaturma disciplinaTurma)
        {
            repositorio.Salvar(disciplinaTurma);
        }

        public void Excluir(gesc_disciplinaturma disciplinaTurma)
        {
            repositorio.Excluir(disciplinaTurma);
        }

        public IEnumerable<gesc_disciplinaturma> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_disciplinaturma ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
