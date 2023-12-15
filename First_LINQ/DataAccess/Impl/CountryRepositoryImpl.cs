using First_LINQ.DataAccess.Contracts;
using First_LINQ.DataAccess.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;

namespace First_LINQ.DataAccess.Impl
{
    internal class CountryRepositoryImpl : CountryRepository
    {
        private const string SQL_GET_ALL = "SELECT * FROM Countries";
        private List<Country?> countries;
        private SQLiteFactory SqliteFactory { get; init; }
        public string ConnectionString { get; init; }
        public CountryRepositoryImpl(string connectionString)
        {
            ConnectionString = connectionString;
            SqliteFactory = new();
            GetAll();
        }

        private async Task GetAll()
        {
            countries = new List<Country?>();
            using DbConnection connection = SqliteFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            await connection.OpenAsync();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = SQL_GET_ALL;
            Stopwatch stopwatch = Stopwatch.StartNew();
            using DbDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                Country country = new Country
                {
                    CountryId = reader.GetInt32("CountryId"),
                    CountryName = reader.GetString("CountryName"),
                    CapitalName = reader.GetString("CapitalName"),
                    Population = reader.GetInt32("Population"),
                    Area = reader.GetDouble("Area"),
                    Region = (WorldRegion)reader.GetInt32("WorldRegion")
                };
                countries.Add(country);
            }
        }

        public void DisplayAllInfoCountries()
        {
            foreach (var country in countries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void DisplayAllCountries()
        {
            var countryNames = countries.Select(c => c.CountryName);
            foreach (var name in countryNames)
            {
                Console.WriteLine(name);
            }
        }

        public void DisplayCapitalNames()
        {
            var capitalNames = countries.Select(c => c.CapitalName);
            foreach (var capital in capitalNames)
            {
                Console.WriteLine(capital);
            }
        }

        public void DisplayEuropeanCountries()
        {
            var europeanCountries = countries.Where(c => c.Region == (WorldRegion)1).Select(c => c.ToString());
            foreach (var country in europeanCountries)
            {
                Console.WriteLine(country);
            }
        }

        public void DisplayCountriesWithAreaGreaterThan(double areaThreshold)
        {
            var countriesWithLargeArea = countries.Where(c => c.Area > areaThreshold).Select(c => c.ToString());
            foreach (var country in countriesWithLargeArea)
            {
                Console.WriteLine(country);
            }
        }

        public void DisplayCountriesWithLetters(string letters)
        {
            var filteredCountries = countries.Where(c => letters.All(l => c.CountryName.Contains(l)));
            foreach (var country in filteredCountries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void DisplayCountriesWithLetterA()
        {
            var filteredCountries = countries.Where(c => c.CountryName.Contains("a", StringComparison.OrdinalIgnoreCase));
            foreach (var country in filteredCountries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void DisplayCountriesWithAreaInRange(double minArea, double maxArea)
        {
            var filteredCountries = countries.Where(c => c.Area >= minArea && c.Area <= maxArea);
            foreach (var country in filteredCountries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void DisplayCountriesWithPopulationGreaterThan(int populationThreshold)
        {
            var filteredCountries = countries.Where(c => c.Population > populationThreshold);
            foreach (var country in filteredCountries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void DisplayTopCountriesByPopulation(int topCount)
        {
            var topCountriesByPopulation = countries.OrderByDescending(c => c.Population).Take(topCount);
            foreach (var country in topCountriesByPopulation)
            {
                Console.WriteLine(country);
            }
        }

        public void DisplayCountryWithLargestArea()
        {
            var countryWithLargestArea = countries.OrderByDescending(c => c.Area).First();
            Console.WriteLine($"Country with largest area:\n{countryWithLargestArea}\n");
        }

        public void DisplayCountryWithLargestPopulation()
        {
            var countryWithLargestPopulation = countries.OrderByDescending(c => c.Population).First();
            Console.WriteLine($"Country with largest population:\n{countryWithLargestPopulation}\n");
        }

        public void DisplayCountryWithSmallestAreaInAfrica()
        {
            var countryWithSmallestAreaInAfrica = countries
             .Where(c => c.Region == (WorldRegion)3)
             .OrderBy(c => c.Area)
             .FirstOrDefault();

            if (countryWithSmallestAreaInAfrica != null)
            {
                Console.WriteLine($"Country with smallest area in Africa:\n{countryWithSmallestAreaInAfrica}\n");
            }
            else
            {
                Console.WriteLine("Havent Africa\n");
            }
        }

        public void DisplayAverageAreaInAsia()
        {
            var asiaCountries = countries.Where(c => c.Region == (WorldRegion)2);

            if (asiaCountries.Any())
            {
                var averageAreaInAsia = asiaCountries.Average(c => c.Area);
                Console.WriteLine($"Average area in Asia: {averageAreaInAsia}\n");
            }
            else
            {
                Console.WriteLine("Havent Asia\n");
            }
        }
    }
}

