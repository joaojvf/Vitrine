using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vitrine.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [MinLength(5, ErrorMessage ="O nome deve ter pelo menos 5 caracteres")]
        [MaxLength(60, ErrorMessage ="O nome deve ter no máximo 60 caracteres")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
