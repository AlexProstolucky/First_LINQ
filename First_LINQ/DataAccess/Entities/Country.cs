namespace First_LINQ.DataAccess.Entities
{
    internal class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CapitalName { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public WorldRegion Region { get; set; }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{CountryId} | {CountryName} | {CapitalName} | {Population} | {Area} | {Region}";
        }
    }
}
