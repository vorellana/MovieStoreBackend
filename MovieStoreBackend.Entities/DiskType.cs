#nullable disable
using MovieStoreBackend.Entities.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreBackend.Entities
{
    public class DiskType : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Name { get; set; }

        // Relationships
        public List<Disk> Disks { get; set; }

    }
}
