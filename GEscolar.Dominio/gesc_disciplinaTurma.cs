using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_disciplinaturma
    {
        [DisplayName("Código")]
        public int DTU_IN_CODIGO { get; set; }

        [DisplayName("Disciplina")]
        [Required(ErrorMessage = "Informe a Disciplina")]
        public int DIS_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe a Turma")]
        [DisplayName("Turma")]
        public int TUR_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe o Professor")]
        [DisplayName("Professor")]
        public int PRO_IN_CODIGO { get; set; }

        public virtual gesc_disciplina Disciplinas { get; set; }

        public virtual gesc_turma Turmas { get; set; }

        public virtual gesc_professor Professores { get; set; }

        public ICollection<gesc_falta> Faltas { get; set; }

        public ICollection<gesc_nota> Notas { get; set; }
    }
}
