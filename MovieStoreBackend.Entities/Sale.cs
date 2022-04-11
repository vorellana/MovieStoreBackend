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
        public List<SaleDetail> SalesDetails { get; set; }

        public Customer Customer { get; set; }
    }
}
