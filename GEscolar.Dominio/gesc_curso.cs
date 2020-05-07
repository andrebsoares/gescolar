using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_curso
    {
        [DisplayName("Código")]
        public int CUR_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Informe o nome do curso")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Descrição deve ter no maximo 50 e no minimo 3 caractéres")]
        [DisplayName("Curso")]
        public string CUR_ST_DESCRICAO { get; set; }

        [Required(ErrorMessage = "Informe a Duração do curso")]
        [DisplayName("Duração")]
        public int CUR_IN_DURACAO { get; set; }

        [Required(ErrorMessage = "Informe o Tipo do curso")]
        [DisplayName("Tipo")]
        public string CUR_CH_TIPO { get; set; }

        public virtual ICollection<gesc_turma> Turmas { get; set; } 
    }
}
