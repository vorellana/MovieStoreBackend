#nullable disable

namespace MovieStoreBackend.DTO
{
    public class MoviesByCustomerDTO
    {
        public int Id { get; set; }
        public string DiskCode { get; set; }
        public string DiskStatus { get; set; }
        public string DiskType { get; set; }
        public string MovieName { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string CategoryName { get; set; }
        public string DocType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
    }
}
