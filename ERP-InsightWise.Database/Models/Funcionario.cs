using System;
using System.ComponentModel;

namespace ERP_InsightWise.Database.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [DefaultValue("João")]
        public string PrimeiroNome { get; set; }

        [DefaultValue("Silva")]
        public string Sobrenome { get; set; }

        [DefaultValue("Analista de Sistemas")]
        public string Cargo { get; set; }

        [DefaultValue(3000.0)]
        public decimal Salario { get; set; }

        [DefaultValue(typeof(DateTime), "1985-05-15")]
        public DateTime DataNascimento { get; set; }

        [DefaultValue(typeof(DateTime), "2022-01-10")]
        public DateTime DataContratacao { get; set; }

        [DefaultValue("Rua das Flores, 123")]
        public string Endereco { get; set; }

        [DefaultValue("(11) 91234-5678")]
        public string Telefone { get; set; }

        [DefaultValue("joao.silva@empresa.com")]
        public string Email { get; set; }

        [DefaultValue("TI")]
        public string Departamento { get; set; }

        [DefaultValue("Ativo")]
        public string Status { get; set; }

        [DefaultValue("Masculino")]
        public string Genero { get; set; }

        [DefaultValue("40h")]
        public string CargaHoraria { get; set; }
    }
}
