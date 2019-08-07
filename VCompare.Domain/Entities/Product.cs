namespace VCompare.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PriceCalculationModel PriceCalculationModel { get; set; }
    }
}