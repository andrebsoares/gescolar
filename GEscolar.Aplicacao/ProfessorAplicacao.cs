using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class ProfessorAplicacao
    {
        private readonly IRepositorio<gesc_professor> repositorio;

        public ProfessorAplicacao(IRepositorio<gesc_professor> repo )
        {
            repositorio = repo;
        }

        public void Salvar(gesc_professor professor)
        {
            repositorio.Salvar(professor);
        }

        public void Excluir(gesc_professor professor)
        {
            repositorio.Excluir(professor);
        }

        public IEnumerable<gesc_professor> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_professor ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
