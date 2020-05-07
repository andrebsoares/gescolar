using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class DisciplinaAplicacao
    {
        private readonly IRepositorio<gesc_disciplina> repositorio;

        public DisciplinaAplicacao(IRepositorio<gesc_disciplina> repo)
        {
            repositorio = repo;
        }

        public void Salvar(gesc_disciplina disciplina)
        {
            repositorio.Salvar(disciplina);
        }

        public void Excluir(gesc_disciplina disciplina)
        {
            repositorio.Excluir(disciplina);
        }

        public IEnumerable<gesc_disciplina> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_disciplina ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
