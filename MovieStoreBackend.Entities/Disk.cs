#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class Disk : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } // Rentada, Comprada, Disponible

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Comment { get; set; }

        // Relationships
        public int MovieId { get; set; }

        public List<SaleDetail> SalesDetails { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie  { get; set; }

        public DiskType DiskType { get; set; }
    }
}
