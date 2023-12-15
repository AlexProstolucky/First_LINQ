using First_LINQ.DataAccess.Impl;
using First_LINQ.DataAccess.Utils;

namespace First_LINQ
{
    internal class AppConfig
    {
        public static async Task Initialize()
        {
            ConnectionStringHolder connectionStringHolder = new ConnectionStringHolder();
            CreateDataBase DB = new();
            CountryRepositoryImpl CRI = new(connectionStringHolder.GetConnectionString());
            Console.WriteLine("ALL INFO");
            CRI.DisplayAllInfoCountries();

            Console.WriteLine("\n\nALL COUNTRY:");
            CRI.DisplayAllCountries();

            Console.WriteLine("\n\nALL CAPITAL:");
            CRI.DisplayCapitalNames();

            Console.WriteLine("\n\nALL European Countries:");
            CRI.DisplayEuropeanCountries();

            Console.WriteLine("\n\nCountries with area greater than 5_000_000:");
            CRI.DisplayCountriesWithAreaGreaterThan(5_000_000);


            Console.WriteLine("\n\nCountries with letters \'a\' \'u\'");
            CRI.DisplayCountriesWithLetters("au");

            Console.WriteLine("\n\nCountries with letter A");
            CRI.DisplayCountriesWithLetterA();

            Console.WriteLine("\n\nCountries with area in diapasone (1_000_000, 7_000_000)");
            CRI.DisplayCountriesWithAreaInRange(1_000_000, 7_000_000);

            Console.WriteLine("\n\nCountries with population in diapasone over 5_000_000");
            CRI.DisplayCountriesWithPopulationGreaterThan(5_000_000);
        }
    }
}
