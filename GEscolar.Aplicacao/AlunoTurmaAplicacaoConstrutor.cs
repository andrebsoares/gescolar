using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class AlunoTurmaAplicacaoConstrutor
    {
        public static AlunoTurmaAplicacao AlunoTurmaAplicacaoEF()
        {
            return new AlunoTurmaAplicacao(new AlunoTurmaRepositorioEF());
        }
    }
}
