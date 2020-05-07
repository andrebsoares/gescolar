using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_aluno
    {
        [DisplayName("Código")]
        public int ALU_IN_CODIGO { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        [DisplayName("Nome")]
        public string ALU_ST_NOME { get; set; }

        [Required(ErrorMessage = "Preencha a Senha")]
        [DisplayName("Senha")]
        public string ALU_ST_SENHA { get; set; }
        
        [Required(ErrorMessage = "Preencha o CPF")]
        [DisplayName ("CPF")]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "Informe o CPF correto")]
        public string ALU_ST_CPF { get; set; }

        [Required(ErrorMessage = "Informe o Status")]
        [DisplayName("Status")]
        public string ALU_CH_STATUS { get; set; }

        public virtual ICollection<gesc_alunoturma> AlunosTurma { get; set; }
    }
}
