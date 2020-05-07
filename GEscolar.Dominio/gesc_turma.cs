using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_turma
    {
        [DisplayName("Código")]
        public int TUR_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe a Descrição da turma")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Descrição deve ter no máximo 50 e minimo 3 caractéres")]
        [DisplayName("Turma")]
        public string TUR_ST_DESCRICAO { get; set; }

        [Required(ErrorMessage = "Informe o Período")]
        [DisplayName("Período")]
        public string TUR_CH_PERIODO { get; set; }

        [DisplayName("Curso")]
        public int CUR_IN_CODIGO { get; set; }
        
        public virtual gesc_curso Cursos { get; set; }

        public ICollection<gesc_alunoturma> AlunosTurmas { get; set; } 

        public ICollection<gesc_disciplinaturma> DisciplinasTurmas { get; set; } 
    }
}
