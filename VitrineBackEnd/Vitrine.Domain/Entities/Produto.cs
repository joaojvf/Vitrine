using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vitrine.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="O Título deve ter ao menos 3 caracteres.")]
        [MaxLength(60, ErrorMessage ="O Título deve ter no máximo 60 caracteres.")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
