namespace OnionApp.Domain.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public virtual List<CarFeature> CarFeatures { get; set; }
    }
}
