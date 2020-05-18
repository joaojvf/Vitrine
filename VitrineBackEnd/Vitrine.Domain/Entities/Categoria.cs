using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vitrine.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(60, ErrorMessage = "EEste campo deve conter ebtre 3 a 60 caracteres.")]
        [MinLength(3, ErrorMessage = "EEste campo deve conter ebtre 3 a 60 caracteres.")]
        public string Nome { get; set; }
    }
}
