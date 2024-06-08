using Senai.Domain.DTos;
using Senai.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Interfaces
{
    public interface IProfessorService
    {
        bool Adicionar(ProfessorDto model);
        bool Remover(long id);
        Professor? BuscarPorId(long id);
        List<Professor> BuscarTodos();
    }
}
