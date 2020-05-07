using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class FaltaAplicacao
    {
        private readonly IRepositorio<gesc_falta> repositorio;

        public FaltaAplicacao(IRepositorio<gesc_falta> repo )
        {
            repositorio = repo;
        }

        public void Salvar(gesc_falta falta)
        {
            repositorio.Salvar(falta);
        }

        public void Excluir(gesc_falta falta)
        {
            repositorio.Excluir(falta);
        }

        public IEnumerable<gesc_falta> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_falta ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
