namespace KAOW.Models
{
    public class EventoInstituicao
    {
        // Chave composta representando o relacionamento N:N opcional entre EventoExtremo e Instituicao
        public int EventoExtremoId { get; set; }
        public EventoExtremo EventoExtremo { get; set; }

        public int InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}