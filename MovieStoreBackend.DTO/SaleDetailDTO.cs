#nullable disable

namespace MovieStoreBackend.DTO
{
    public class SaleDetailDTO
    {
        public int DiskId { get; set; }
        public int SaleId { get; set; }
        public string Type { get; set; } // compra, renta
        public decimal Amount { get; set; }
        public int MovieId { get; set; }
    }
}
