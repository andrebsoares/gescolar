using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class AlunoAplicacaoConstrutor
    {
        public static AlunoAplicacao AlunoAplicacaoEF()
        {
            return new AlunoAplicacao(new AlunoRepositorioEF());
        }
    }
}
