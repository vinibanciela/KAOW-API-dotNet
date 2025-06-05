namespace KAOW.DTOs
{
    // DTO básico para vincular ou desvincular EventoExtremo e Instituicao
    public class EventoInstituicaoDTO
    {
        public int EventoExtremoId { get; set; }
        public int InstituicaoId { get; set; }
    }
}