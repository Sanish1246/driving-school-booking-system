using System.Globalization;
using CsvHelper.Configuration;
using MainProject.Models;

namespace MainProject.CSVHeaders;

public sealed class CarMap : ClassMap<Car>
{
    public CarMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(c => c.CarId).Ignore();
    }
}