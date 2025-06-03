namespace KAOW.Models
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } // Público ou Privado
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }

        // Relacionamento N:N opcional com EventoExtremo via tabela associativa EventoInstituicao
        // Várias instituicoes podem estar associadas a vários EventosExtremos, ou a nenhum. A ausência de registros na associativa representa a opcionalidade do relacionamento.
        public ICollection<EventoInstituicao> EventoInstituicoes { get; set; }

        // Relacionamento 1:N opcional com BaseEmergencia
        // Uma Instituicao pode ter várias BasesEmergencia, ou nenhuma
        public ICollection<BaseEmergencia> BasesEmergencia { get; set; }
    }
}