using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
//adiciona biblioteca para formata data  System.ComponentModel.DataAnnotations

namespace BLL
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do contato deve ser informado.!")]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Idade { get; set; }
        //Formata data;
        [Required(ErrorMessage = "Data Invalida!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataNascimento { get; set; }
        [Required(ErrorMessage = "Selecione o Sexo")]
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Texto { get; set; }
        public DateTime DataEscricao { get; set; }

        public int CalculaIdade()
        {
            Idade = DateTime.Now.Year - Convert.ToDateTime(DataNascimento).Year;
            return  Idade;
        }
    }

   
}
