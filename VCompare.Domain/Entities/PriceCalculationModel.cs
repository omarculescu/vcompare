namespace VCompare.Domain.Entities
{
    public class PriceCalculationModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Base { get; set; }
        public decimal Amount { get; set; }
        public int? Limit { get; set; }
        public decimal PricePerKWH { get; set; }
        public Product Product { get; set; }

        public decimal CalculatePriceForAverageConsumption(int consumption)
        {
            var fixedCost = Base * Amount;
            if (Limit != null)
            {
                consumption -= Limit.Value;
            }
            if (consumption < 0)
            {
                return fixedCost;
            }
            return fixedCost + consumption * PricePerKWH;
        }
    }
}