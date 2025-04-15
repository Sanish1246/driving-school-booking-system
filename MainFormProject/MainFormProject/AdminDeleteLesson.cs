using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;
using MainFormProject.Models;

namespace MainFormProject
{
    public partial class AdminDeleteLesson : Form
    {
        private string operation;
        private string studentEmail;
        private string instructorEmail;
        private string regNo;
        public AdminDeleteLesson(string operation, string newStudentEmail, string newInstructorEmail,string newCarRegNo)
        {
            InitializeComponent();
            this.operation = operation;
            studentEmail = newStudentEmail;
            instructorEmail = newInstructorEmail;
            regNo = newCarRegNo;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (operation == "delete")
            {
                LessonHandler lessonHandlerMenu = new LessonHandler();

                this.Close();

                lessonHandlerMenu.Show();
            } else
            {
                BookCar bookCar = new BookCar(studentEmail,instructorEmail);

                this.Close();

                bookCar.Show();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string lessonDate = LessonDate.Value.ToString("yyyy/MM/dd");
            DateOnly newLessonDate = DateOnly.ParseExact(lessonDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            if (operation == "delete")
            {

                AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu(newLessonDate);

                this.Close();

                deleteLessonMenu.Show();
            } else
            {
                int studentId = 0;
                int instructorId = 0;
                int carId = 0;
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var student = context.Students.Select(s => new
                        {
                            studentId = s.StudentId,
                            email = s.Email
                        }).First(s => s.email == studentEmail);
                        studentId = student.studentId;

                        var instructor = context.Instructors.Select(i => new
                        {
                            instructorId = i.InstructorId,
                            email = i.Email
                        }).First(i => i.email == instructorEmail);
                        instructorId = instructor.instructorId;

                        var car = context.Cars.Select(c => new
                        {
                            CarID = c.CarId,
                            regNumber = c.RegistrationNumber
                        }).First(c => c.regNumber == regNo);
                        carId = car.CarID;

                        var lesson = new Lesson()
                        {
                            CarId = carId,
                            StudentId = studentId,
                            InstructorId = instructorId,
                            Date = newLessonDate
                        };

                        context.Lessons.Add(lesson);
                        context.SaveChanges();

                        // Add to hash table
                        Console.WriteLine(lesson.LessonId);
                        table.LessonTable.Insert(lesson.LessonId, lesson);
                        MessageBox.Show($"Lesson booked with id {lesson.LessonId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
