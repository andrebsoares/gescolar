using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_alunoturma
    {
        [DisplayName("Código")]
        public int ALT_IN_CODIGO { get; set; }

        [DisplayName("Aluno")]
        public int ALU_IN_CODIGO { get; set; }

        [DisplayName("Turma")]
        public int TUR_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe o Status")]
        [DisplayName("Status")]
        public string ALT_CH_STATUS { get; set; }

        public virtual gesc_aluno Alunos { get; set; }

        public virtual gesc_turma Turmas { get; set; }

        public ICollection<gesc_falta> Faltas { get; set; }

        public ICollection<gesc_nota> Notas { get; set; }
    }
}
