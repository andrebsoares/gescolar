using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEscolar.Dominio.contrato
{
    public interface IRepositorioAlunoTurma<T> : IRepositorio<T> where T : class 
    {
        IEnumerable<T> ListaAlunosTurma(string codTurma); 
    }
}
