using System.Data.SQLite;

namespace First_LINQ.DataAccess.Utils
{
    internal class CreateDataBase
    {
        private ConnectionStringHolder ConnectionS = new();
        public CreateDataBase()
        {
            SQLiteFactory factory = new();
            SQLiteConnection.CreateFile("country.sqlite");

            using SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection();
            connection.ConnectionString = ConnectionS.GetConnectionString();
            connection.OpenAsync();

            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE Countries (
                CountryId INTEGER PRIMARY KEY AUTOINCREMENT,
                CountryName TEXT NOT NULL,
                CapitalName TEXT NOT NULL,
                Population INTEGER,
                Area REAL,
                WorldRegion INT CHECK(WorldRegion IN (1, 2, 3, 4, 5, 6)) NOT NULL);
            ";

            command.ExecuteNonQuery();

            create_data();
        }

        private void create_data()
        {
            SQLiteFactory factory = new();
            using SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection();
            connection.ConnectionString = ConnectionS.GetConnectionString();
            connection.OpenAsync();

            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM Countries;

                    INSERT INTO Countries (CountryName, CapitalName, Population, Area, WorldRegion) VALUES
                        ('Ukraine', 'Kyiv', 44000000, 603500, 2),
                        ('Germany', 'Berlin', 83000000, 357022, 1),
                        ('France', 'Paris', 67000000, 551695, 1),
                        ('United Kingdom', 'London', 66000000, 243610, 1),
                        ('China', 'Beijing', 1400000000, 9596961, 2),
                        ('India', 'New Delhi', 1380000000, 3287263, 2),
                        ('Nigeria', 'Abuja', 206000000, 923768, 3),
                        ('United States', 'Washington, D.C.', 331000000, 9833517, 4),
                        ('Brazil', 'Brasília', 213000000, 8515767, 5),
                        ('Australia', 'Canberra', 26000000, 7692024, 6),
                        ('Japan', 'Tokyo', 126000000, 377975, 2),
                        ('South Africa', 'Pretoria', 60000000, 1220813, 3),
                        ('Canada', 'Ottawa', 38000000, 9976140, 4),
                        ('Mexico', 'Mexico City', 128000000, 1964375, 5);
            ";

            command.ExecuteNonQuery();
        }
    }
}
