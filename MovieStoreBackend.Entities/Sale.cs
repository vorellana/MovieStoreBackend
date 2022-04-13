#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class Sale : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Type { get; set; } // Boleta, Factura

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime IssuedAt{ get; set; }


        // Relationships
        public int CustomerId { get; set; }

        public List<SaleDetail> SalesDetails { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
