using System.Collections.Generic;
using GEscolar.Dominio;
using GEscolar.Dominio.contrato;

namespace GEscolar.Aplicacao
{
    public class NotaAplicacao
    {
        private readonly IRepositorio<gesc_nota> repositorio;

        public NotaAplicacao(IRepositorio<gesc_nota> repo )
        {
            repositorio = repo;
        }

        public void Salvar(gesc_nota nota)
        {
            repositorio.Salvar(nota);
        }

        public void Excluir(gesc_nota nota)
        {
            repositorio.Excluir(nota);
        }

        public IEnumerable<gesc_nota> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public gesc_nota ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
