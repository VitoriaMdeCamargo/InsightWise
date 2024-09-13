namespace ERP_InsightWise.Database.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Status { get; set; }
        public string Genero { get; set; }
        public string CargaHoraria { get; set; }
    }

}
