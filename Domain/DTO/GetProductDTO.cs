namespace Domain.DTO
{
    public class GetProductDTO
    {
        public string? Id { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}