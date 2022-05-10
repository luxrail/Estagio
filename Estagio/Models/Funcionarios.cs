using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estagio.Models
{
    [Table("Funcionario")]
    public class Funcionarios
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "varchar (150)")]
        [Display(Name = "nome")]
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        [Column("Nascimento")]
        [Display(Name = "data")]
        public DateTime Nascimento { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "numeric (18,2)")]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Column(TypeName = "varchar (max)")]
        [Display(Name = "Atividade")]
        public string? Atividade { get; set; }
    }
}
