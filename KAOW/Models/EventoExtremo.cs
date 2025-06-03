namespace KAOW.Models
{
    public class EventoExtremo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // Tipo do evento extremo: enchente, incêndio, etc.
        public string Local { get; set; }

        // Relacionamento N:N opcional com Instituicao via tabela associativa EventoInstituicao
        // Um EventoExtremo pode estar associado a várias Instituicoes, ou a nenhuma
        public ICollection<EventoInstituicao> EventoInstituicoes { get; set; }

        // Relacionamento 1:N opcional com BaseEmergencia
        // Um EventoExtremo pode ter várias BasesEmergencia associadas, ou nenhuma
        public ICollection<BaseEmergencia> BasesEmergencia { get; set; }
    }
}