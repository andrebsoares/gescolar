using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class DisciplinaAplicacaoConstrutor
    {
        public static DisciplinaAplicacao DisciplinaAplicacaoEF()
        {
            return new DisciplinaAplicacao(new DisciplinaRepositorioEF());
        }
    }
}
