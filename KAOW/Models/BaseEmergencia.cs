namespace KAOW.Models
{
    public class BaseEmergencia
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; } // Tipo da base: ambulância, ponto de apoio etc.

        // Relacionamento opcional N:1 com Instituicao
        // Uma BaseEmergencia pode estar associada a uma Instituicao, ou a nenhuma
        public int? InstituicaoId { get; set; }
        public Instituicao Instituicao { get; set; }

        // Relacionamento opcional N:1 com EventoExtremo
        // Uma BaseEmergencia pode estar associada a um EventoExtremo, ou a nenhum
        public int? EventoExtremoId { get; set; }
        public EventoExtremo EventoExtremo { get; set; }
    }
}