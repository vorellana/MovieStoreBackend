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
    public class SaleDetail : TrackableEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string type { get; set; } // venta, renta

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }

        // Relationships
        public Disk Disk { get; set; }
        public Sale Sale { get; set; }
    }
}
