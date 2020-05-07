using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEscolar.Dominio
{
    public class gesc_professor
    {
        [DisplayName("Código")]
        public int PRO_IN_CODIGO { get; set; }
        
        [Required(ErrorMessage = "Preencha o Nome")]
        [DisplayName("Nome")]
        public string PRO_ST_NOME { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]        
        [StringLength(20,MinimumLength = 8)]
        [DisplayName("Senha")]
        public string PRO_ST_SENHA { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [StringLength(11,MinimumLength = 11, ErrorMessage = "Informe o CPF correto")]
        [DisplayName("CPF")]
        public string PRO_ST_CPF { get; set; }

        [Required(ErrorMessage = "Informe o Status")]
        [DisplayName("Tipo")]
        public string PRO_CH_TIPO { get; set; }
        
        [DisplayName("Email")]
        public string PRO_ST_EMAIL { get; set; }

        public ICollection<gesc_disciplinaturma> DisciplinasTurmas { get; set; } 
    }
}
