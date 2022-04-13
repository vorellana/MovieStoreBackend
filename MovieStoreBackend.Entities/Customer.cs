#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class Customer: TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string LastNames { get; set; }

        // Relationship
        public List<Sale> Sales { get; set; }

    }
}
