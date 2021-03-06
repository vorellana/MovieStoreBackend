#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class Movie : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal RentalPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal PurchasePrice { get; set; }

        // Relationships
        public MovieCategory MovieCategory { get; set; }

        public List<Disk> Disks { get; set; }
    }
}
