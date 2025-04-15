using System.Globalization;
using CsvHelper.Configuration;
using MainFormProject.Models;

namespace MainFormProject.CSVHeaders;

public sealed class LessonMap : ClassMap<Lesson>
{
    public LessonMap()
    {
        Map(l => l.StudentId).Name("studentid");
        Map(l => l.InstructorId).Name("instructorid");
        Map(l => l.CarId).Name("carid");
        Map(l => l.Date).Name("date");
        Map(l => l.LessonId).Ignore();
    }
}