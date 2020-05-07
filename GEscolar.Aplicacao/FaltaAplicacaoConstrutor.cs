using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class FaltaAplicacaoConstrutor
    {
        public static FaltaAplicacao FaltaAplicacaoEF()
        {
            return new FaltaAplicacao(new FaltaRepositorioEF());
        }
    }
}
