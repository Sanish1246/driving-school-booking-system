using System.Globalization;
using CsvHelper.Configuration;
using MainProject.Models;

namespace MainProject.CSVHeaders;

public sealed class StudentMap : ClassMap<Student>
{
    public StudentMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(s => s.StudentId).Ignore();
    }
}