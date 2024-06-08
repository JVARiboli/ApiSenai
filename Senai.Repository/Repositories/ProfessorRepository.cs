using Microsoft.EntityFrameworkCore;
using Senai.Domain.Entidades;
using Senai.Domain.Interfaces;
using Senai.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Repository.Repositories
{
    internal class ProfessorRepository : IProfessorRepository
    {
        private readonly SenaiContext _context;

        public ProfessorRepository(SenaiContext context)
        {
            _context = context;
        }

        public bool Salvar(Professor entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    _context.Professor.Add(entity);
                }
                else
                {
                    _context.Professor.Update(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Adicionar(Professor entity)
        {
            try
            {
                _context.Professor.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Professor> BuscarTodos()
        {
            return _context.Professor.ToList();
        }
        public Professor? BuscarPorId(long id)
        {
            return _context.Professor.FirstOrDefault(c => c.Id == id);
        }
        public bool Remover(long id)
        {
            try
            {
                var escola = BuscarPorId(id);
                if (escola != null)
                {
                    _context.Professor.Remove(escola);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task RemoverPorId(long id)
        {
            var sql = $"DELETE \"Professor\" e WHERE e.\"Id\" = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
