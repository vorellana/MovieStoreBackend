#nullable disable
using MovieStoreBackend.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
