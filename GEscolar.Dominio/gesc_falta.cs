using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_falta
    {
        [DisplayName("Código")]
        public int FAL_IN_CODIGO { get; set; }

        [DisplayName("Aluno Turma")]
        public int ALT_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe a Data da falta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data")]
        public DateTime FAL_DT_DIA { get; set; }

        [Required(ErrorMessage = "Informe Quantidade de faltas")]
        [DisplayName("Quantidade")]
        public int FAL_IN_QTDE { get; set; }

        [DisplayName("Disciplina")]
        public int DTU_IN_CODIGO { get; set; }

        public virtual gesc_alunoturma AlunoTurmas { get; set; }

        public virtual gesc_disciplinaturma DisciplinasTurmas { get; set; }
    }
}
