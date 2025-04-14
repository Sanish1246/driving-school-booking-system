using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;
using MainFormProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MainFormProject
{
    public partial class AdminAddLesson : Form
    {
        public AdminAddLesson()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LessonHandler lessonHandlerMenu = new LessonHandler();

            this.Close();

            lessonHandlerMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string studentEmail = StudentEmail.Text;
            string instructorEmail = InstructorEmail.Text;
            string lessonDate = LessonDate.Value.ToString("yyyy/MM/dd");
            DateOnly newLessonDate = DateOnly.ParseExact(lessonDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            string regNo = RegNo.Text;
            int studentId=0;
            int instructorId=0;
            int carId = 0;
            bool valid = true;

            invalidStudent.Hide();
            invalidInstructor.Hide();
            invalidRegNo.Hide();
            if (Validations.ValidateString(studentEmail))
            {
                // Validate the email
                if (Validations.ValidateEmail(studentEmail))
                {
                    // Check if email is already present in database; 
                    if (CheckStudentEmailExistence(studentEmail))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var student = context.Students.Select(s => new
                                {
                                    studentId = s.StudentId,
                                    email = s.Email
                                }).First(s => s.email == studentEmail);
                                studentId = student.studentId;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } else
                    {
                        invalidStudent.Text = "Email does not exist.";
                        valid = false;
                        invalidStudent.Show();
                    }
                }
                else
                {
                    invalidStudent.Text = "format should be in the form John.Doe@example.com";
                    valid = false;
                    invalidStudent.Show();
                }
            }
            else
            {
                invalidStudent.Text = "Email can't be empty";
                valid = false;
                invalidStudent.Show();

            }

            if (Validations.ValidateString(instructorEmail))
            {

                // Validate the email
                if (Validations.ValidateEmail(instructorEmail))
                {
                    // Check if email is already present in database; 
                    if (CheckInstructorEmailExistence(instructorEmail))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var instructor = context.Instructors.Select(i => new
                                {
                                    instructorId = i.InstructorId,
                                    email = i.Email
                                }).First(i => i.email == instructorEmail);
                                instructorId = instructor.instructorId;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }  else
                    {
                        invalidInstructor.Text = "Email not present.";
                        valid = false;
                        invalidInstructor.Show();
                    }
                }
                else
                {
                    invalidInstructor.Text = "format should be in the form John.Doe@example.com";
                    valid = false;
                    invalidInstructor.Show();
                }
            }
            else
            {
                invalidInstructor.Text = "Email can't be empty";
                valid = false;
                invalidInstructor.Show();
            }

            if (Validations.ValidateString(regNo))
            {
                if (CarRegistrationChecker(regNo))
                {
                    if (!IsUnique(regNo))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var car = context.Cars.Select(c => new
                                {
                                    CarID = c.CarId,
                                    regNumber = c.RegistrationNumber
                                }).First(c => c.regNumber == regNo);
                                carId = car.CarID;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } else
                    {
                        invalidRegNo.Text = "Registration number doesn't exist";
                        valid = false;
                        invalidRegNo.Show();
                    }
                }
                else
                {
                    invalidRegNo.Text = "Invalid registration number format";
                    valid = false;
                    invalidRegNo.Show();
                }
            }
            else
            {
                invalidRegNo.Text = "Registration number can't be empty";
                valid = false;
                invalidRegNo.Show();
            }

            if (valid)
            {
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
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
                        MessageBox.Show($"Lesson added with id {lesson.LessonId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static bool CheckStudentEmailExistence(string email)
        {
            // Connect with Database
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Students.Any(i => i.Email == email);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            return success;
        }

        public static bool CheckInstructorEmailExistence(string email)
        {
            // Connect with Database
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Instructors.Any(i => i.Email == email);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            return success;
        }

        public static bool CarRegistrationChecker(string registrationNumber)
        {
            var registrationNumberRegex = new Regex(@"^[a-zA-Z]{2}[\d]{2}[\s]?[a-zA-Z]{3}$");
            var m = registrationNumberRegex.Match(registrationNumber);
            return m.Success;
        }

        public static bool IsUnique(string registrationNumber)
        {
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Cars.Any(c => c.RegistrationNumber == registrationNumber);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            return !success;
        }
    }
}
