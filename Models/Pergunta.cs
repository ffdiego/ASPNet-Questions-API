using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class Pergunta
    {

        [BsonElement("N")]
        public int N { get; set; }
        [BsonElement("Pergunta")]
        public string Enunciado { get; set; }
        [BsonElement("Materia")]
        public int Materia { get; set; }
        [BsonElement("Dificuldade")]
        public int Nivel { get; set; }
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        public string R4 { get; set; }
        //todo: as vezes quero que este campo venha, as vezes não
        [BsonElement("Certa")]
        public int Certa { get; set; }
        //todo: se eu quisesse salvar todas as alternativas em um array?
        //public string[] Alternativas { get; set; }
        public enum Niveis
        {
            Facil,
            Media,
            Dificil,
            Milhao
        }
        public enum Materias
        {
            Variedades,
            Ciencias,
            Geografia,
            Historia,
            Portugues,
            Ingles,
            Matematica
        }
    }


}
