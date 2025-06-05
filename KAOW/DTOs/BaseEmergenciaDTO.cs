namespace KAOW.DTOs
{
    // DTO de leitura geral de base de emergência (GET simples)
    public class BaseEmergenciaDTO
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }

    // DTO para criação de base de emergência (POST)
    public class CreateBaseEmergenciaDTO
    {
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int? InstituicaoId { get; set; }
        public int? EventoExtremoId { get; set; }
    }

    // DTO para atualização de base de emergência (PUT)
    public class UpdateBaseEmergenciaDTO
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int? InstituicaoId { get; set; }
        public int? EventoExtremoId { get; set; }
    }

    // DTO de leitura detalhada de base de emergência (GET detalhado)
    public class BaseEmergenciaDetailDTO
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string? InstituicaoNome { get; set; }
        public string? EventoExtremoTipo { get; set; }
    }
}