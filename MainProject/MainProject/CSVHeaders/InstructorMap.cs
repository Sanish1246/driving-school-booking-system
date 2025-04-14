using System.Globalization;
using CsvHelper.Configuration;
using MainProject.Models;

namespace MainProject.CSVHeaders;

public sealed class InstructorMap : ClassMap<Instructor>
{
    public InstructorMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(i => i.InstructorId).Ignore();
    }
}