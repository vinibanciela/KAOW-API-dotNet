namespace KAOW.DTOs
{
    // DTO de leitura geral de instituição (GET simples)
    public class InstituicaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
    }

    // DTO para criação de instituição (POST)
    public class CreateInstituicaoDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
    }

    // DTO para atualização de instituição (PUT)
    public class UpdateInstituicaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
    }

    // DTO de leitura detalhada de instituição (GET detalhado)
    public class InstituicaoDetailDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public List<string> BasesEmergencia { get; set; }
        public List<string> EventosExtremos { get; set; }
    }
}