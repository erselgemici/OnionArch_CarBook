namespace OnionApp.Domain.Entities
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
        public virtual List<CarPricing> CarPricings { get; set; }
    }
}
