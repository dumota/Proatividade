

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proatividade_API.Models;
using System.Linq;
using Proatividade_API.Data;
using System;

namespace Proatividade_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;
        public AtividadeController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Atividade> get()
        {
            return _context.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return _context.Atividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            if (_context.SaveChanges() > 0)
            {
                return _context.Atividades;
            }
            else
            {
                throw new Exception("Voce não consegui adicionar uma atividade");
            }

        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            if (atividade.Id != id)
            {
                throw new Exception("Você esta tentando atualizar a atividade errada!");
            }
            _context.Update(atividade);
            if (_context.SaveChanges() > 0)
            {
                return _context.Atividades.FirstOrDefault(ativ=> ativ.Id == id);
            }
            else
            {
                return new Atividade();
            }
        }
        

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = _context.Atividades.FirstOrDefault(ativ=> ativ.Id == id);

            if(atividade == null)
                throw new Exception("Você esta temntando deletar uma atividade que não existe");

                _context.Remove(atividade);

                return _context.SaveChanges() > 0;
        }
    }
}