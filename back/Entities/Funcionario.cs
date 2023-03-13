using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionarioApi.Entities
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required]
        [StringLength(6)]
        public string Re { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no máximo{80}")]
        public string NomeFuncionario { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(4)]
        public string Ramal { get; set; }

        public string Imagem { get; set; }

    }
}