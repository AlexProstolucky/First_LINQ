namespace First_LINQ.DataAccess.Contracts
{
    internal interface CountryRepository
    {
        void DisplayAllInfoCountries();
        void DisplayAllCountries();
        void DisplayCapitalNames();
        void DisplayEuropeanCountries();

        void DisplayCountriesWithAreaGreaterThan(double areaThreshold);


        void DisplayCountriesWithLetters(string letters);
        void DisplayCountriesWithLetterA();
        void DisplayCountriesWithAreaInRange(double minArea, double maxArea);
        void DisplayCountriesWithPopulationGreaterThan(int populationThreshold);


        void DisplayTopCountriesByPopulation(int topCount);
        void DisplayCountryWithLargestArea();
        void DisplayCountryWithLargestPopulation();
        void DisplayCountryWithSmallestAreaInAfrica();
        void DisplayAverageAreaInAsia();
    }
}
