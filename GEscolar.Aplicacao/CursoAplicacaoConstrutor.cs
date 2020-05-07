using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class CursoAplicacaoConstrutor
    {

        public static CursoAplicacao CursoAplicacaoEF()
        {
            return new CursoAplicacao(new CursoRepositorioEF());
        }
    }
}
