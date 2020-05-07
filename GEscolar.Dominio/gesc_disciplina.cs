using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_disciplina
    {
        [DisplayName("Código")]
        public int DIS_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do curso")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Descrição deve ter no maximo 50 e no minimo 3 caractéres")]
        [DisplayName("Descrição")]
        public string DIS_ST_DESCRICAO { get; set; }

        public ICollection<gesc_disciplinaturma> DisciplinasTurmas { get; set; } 

    }
}
