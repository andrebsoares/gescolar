using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class TurmaAplicacaoConstrutor
    {

        public static TurmaAplicacao TurmaAplicacaoEF()
        {
            return new TurmaAplicacao(new TurmaRepositorioEF());
        }
    }
}
