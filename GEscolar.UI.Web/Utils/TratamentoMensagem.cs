using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEscolar.UI.Web.Utils
{
    public class TratamentoMensagem
    {
        public string ExibeMensagem(int codMsg)
        {
            switch (codMsg)
            {
                case 1: return "Cadastro realizado com sucesso!";
                    break;
                case 2: return "Edição realizada com sucesso!";
                    break;
                case 3: return "Exclusão realizada com sucesso!";
                    break;
                case 51: return "Erro ao apagar o cadastro!";
                    break;
                case 52: return "Cadastro não encontrado!";
                    break;
                case 53: return "Não foi possível apagar o aluno, pois este possui vínculo com alunos turma!";
                    break;
                case 54: return "Não foi possível apagar o aluno turma, pois este possui lançamentos de faltas!";
                    break;
                case 55: return "Não foi possível apagar o aluno turma, pois este possui lançamentos de notas!";
                    break;
                case 56: return "Não foi possível apagar a disciplinas turma, pois esta possui lançamentos de faltas!";
                    break;
                case 57: return "Não foi possível apagar o disciplinas turma, pois esta possui lançamentos de notas!";
                    break;
                default: return "";
                    break;
            }
        }
    }
}