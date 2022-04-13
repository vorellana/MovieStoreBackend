#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class SaleDetail : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Type { get; set; } // compra, renta

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }


        // Relationships
        public int DiskId { get; set; }
        public int SaleId { get; set; }

        [ForeignKey("DiskId")]
        public Disk Disk { get; set; }

        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }
    }
}
