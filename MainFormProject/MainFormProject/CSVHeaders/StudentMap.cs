using System.Globalization;
using CsvHelper.Configuration;
using MainFormProject.Models;

namespace MainFormProject.CSVHeaders;

public sealed class StudentMap : ClassMap<Student>
{
    public StudentMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(s => s.StudentId).Ignore();
    }
}