using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class DisciplinaTurmaAplicacaoConstrutor
    {
        public static DisciplinaTurmaAplicacao DisciplinaTurmaAplicacaoEF()
        {
            return new DisciplinaTurmaAplicacao(new DisciplinaTurmaRepositorioEF());
        }
    }
}
