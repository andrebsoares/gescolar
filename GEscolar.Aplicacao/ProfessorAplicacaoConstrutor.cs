using GEscolar.RepositorioEF;

namespace GEscolar.Aplicacao
{
    public class ProfessorAplicacaoConstrutor
    {
        public static ProfessorAplicacao ProfessorAplicacaoEF()
        {
            return new ProfessorAplicacao( new ProfessorRepositorioEF());
        }
    }
}
