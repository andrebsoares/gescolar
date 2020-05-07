using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_nota
    {
        [DisplayName("Código")]
        public int NOT_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe a Nota")]
        [DisplayName("Nota")]
        public decimal NOT_DE_NOTA { get; set; }

        [DisplayName("Aluno Turma")]
        public int ALT_IN_CODIGO { get; set; }

        [DisplayName("Disciplina Turma")]
        public int DTU_IN_CODIGO { get; set; }

        public virtual gesc_alunoturma ALunosTurmas { get; set; }

        public virtual gesc_disciplinaturma DisciplinasTurmas { get; set; }
    }
}
