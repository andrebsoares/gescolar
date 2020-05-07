using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class AlunoAplicacao
    {
        private readonly IRepositorio<gesc_aluno> repositorio;

        public AlunoAplicacao(IRepositorio<gesc_aluno> repo)
        {
            repositorio = repo;
        }

        public void Salvar(gesc_aluno aluno)
        {
            repositorio.Salvar(aluno);
        }

        public void Excluir(gesc_aluno aluno)
        {
            repositorio.Excluir(aluno);
        }

        public IEnumerable<gesc_aluno> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_aluno ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }

    }
}
