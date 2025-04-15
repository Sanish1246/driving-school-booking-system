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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (operation == "delete"||operation=="update")
            {
                LessonHandler lessonHandlerMenu = new LessonHandler();

                this.Close();

                lessonHandlerMenu.Show();
            }
            else
            {
                BookCar bookCar = new BookCar(studentEmail, instructorEmail);

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
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();

                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var lessons = context.Lessons
                            .Where(l => l.Date == newLessonDate)
                            .Select(l => new
                            {
                                l.LessonId,
                                StudentFirstName = l.Student.FirstName,
                                StudentLastName = l.Student.LastName,
                                StudentEmail = l.Student.Email,
                                InstructorFirstName = l.Instructor.FirstName,
                                InstructorLastName = l.Instructor.LastName,
                                InstructorEmail = l.Instructor.Email,
                                CarTransmission = l.Car.Transmission,
                                LessonDate = l.Date
                            })
                            .ToList();

                        if (lessons.Any())
                        {
                            AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu(newLessonDate, "update");

                            this.Close();

                            deleteLessonMenu.Show();

                        }
                        else
                        {
                            MessageBox.Show("No matching lessons found for the selected date.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operation == "update") {
                bool hasLessons = false;
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();

                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var lessons = context.Lessons
                            .Where(l => l.Date == newLessonDate)
                            .Select(l => new
                            {
                                l.LessonId,
                                StudentFirstName = l.Student.FirstName,
                                StudentLastName = l.Student.LastName,
                                StudentEmail = l.Student.Email,
                                InstructorFirstName = l.Instructor.FirstName,
                                InstructorLastName = l.Instructor.LastName,
                                InstructorEmail = l.Instructor.Email,
                                CarTransmission = l.Car.Transmission,
                                LessonDate = l.Date
                            })
                            .ToList();
                        if (lessons.Any())
                        {
                            hasLessons = true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (hasLessons)
                {
                    AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu(newLessonDate, "update");

                    this.Close();

                    deleteLessonMenu.Show();

                }
                else
                {
                    MessageBox.Show("No matching lessons found for the selected date.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
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
