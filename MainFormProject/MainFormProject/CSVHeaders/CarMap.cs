using System.Globalization;
using CsvHelper.Configuration;
using MainFormProject.Models;

namespace MainFormProject.CSVHeaders;

public sealed class CarMap : ClassMap<Car>
{
    public CarMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(c => c.CarId).Ignore();
    }
}