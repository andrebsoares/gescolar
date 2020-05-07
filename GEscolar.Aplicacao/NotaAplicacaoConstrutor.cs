using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class NotaAplicacaoConstrutor
    {
        public static NotaAplicacao NotaAplicacaoEF()
        {
            return new NotaAplicacao(new NotaRepositorioEF());
        }
    }
}
