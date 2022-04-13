#nullable disable

namespace MovieStoreBackend.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public DateTime IssuedAt { get; set; }
        public List<SaleDetailDTO> SaleDetailDtoList { get; set; }
    }
}
