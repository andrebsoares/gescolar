using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class CursoAplicacao
    {
        private readonly IRepositorio<gesc_curso> repositorio;

        public CursoAplicacao(IRepositorio<gesc_curso> repo)
        {
            repositorio = repo;
        }

        public void Salvar(gesc_curso curso)
        {
            repositorio.Salvar(curso);
        }

        public void Excluir(gesc_curso curso)
        {
            repositorio.Excluir(curso);
        }

        public IEnumerable<gesc_curso> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_curso ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }

    }
}
