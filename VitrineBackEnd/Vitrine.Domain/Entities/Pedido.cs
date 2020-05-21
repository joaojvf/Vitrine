using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Vitrine.Domain.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [AllowNull]
        public DateTime? DataCompra { get; set; }
        
        public DateTime? DataEntrega { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
