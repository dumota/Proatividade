

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proatividade_API.Models;
using System.Linq;

namespace Proatividade_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IEnumerable<Atividade> ListaAtividades = new List<Atividade>()
        {
                new Atividade(1),
                new Atividade(2),
                new Atividade(3)

        };

        [HttpGet]
        public IEnumerable<Atividade> get()
        {
            return ListaAtividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return ListaAtividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            return ListaAtividades.Append<Atividade>(atividade);
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "meu primeiro método put";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "meu primeiro método delete";
        }
    }
}