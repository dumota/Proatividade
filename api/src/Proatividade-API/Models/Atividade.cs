

namespace Proatividade_API.Models
{
    public class Atividade
    {
        public int Id {get;set;}

        public string Titulo { get; set; }

        public string descricao { get; set; }

        public Prioridade prioridade { get; set; }

        public Atividade()
        {
            
        }

        public Atividade(int id)
        {
            Id = id;
        }
    }
}