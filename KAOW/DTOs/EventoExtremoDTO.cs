namespace KAOW.DTOs
{
    // DTO de leitura geral de evento extremo (GET simples)
    public class EventoExtremoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
    }

    // DTO para criação de evento extremo (POST)
    public class CreateEventoExtremoDTO
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
    }

    // DTO para atualização de evento extremo (PUT)
    public class UpdateEventoExtremoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
    }

    // DTO de leitura detalhada de evento extremo (GET detalhado)
    public class EventoExtremoDetailDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
        public List<string> BasesEmergencia { get; set; }
        public List<string> Instituicoes { get; set; }
    }
}