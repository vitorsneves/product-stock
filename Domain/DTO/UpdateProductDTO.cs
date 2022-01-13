namespace Domain.DTO
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}