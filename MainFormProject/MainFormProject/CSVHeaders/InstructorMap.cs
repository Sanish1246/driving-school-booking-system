using System.Globalization;
using CsvHelper.Configuration;
using MainFormProject.Models;

namespace MainFormProject.CSVHeaders;

public sealed class InstructorMap : ClassMap<Instructor>
{
    public InstructorMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(i => i.InstructorId).Ignore();
    }
}