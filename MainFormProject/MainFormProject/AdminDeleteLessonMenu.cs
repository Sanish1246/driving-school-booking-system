﻿using MainFormProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject
{
    public partial class AdminDeleteLessonMenu : Form
    {
        private DateOnly lessonDate;
        private string operation;
        public AdminDeleteLessonMenu(DateOnly newLessonDate,string newOperation)
        {
            InitializeComponent();
            lessonDate = newLessonDate;
            operation = newOperation;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson(operation,"","","");

            this.Close();

            deleteLesson.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminDeleteLessonMenu_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("Lesson ID", 80);
            listView1.Columns.Add("Student First Name", 100);
            listView1.Columns.Add("Student Last Name", 100);
            listView1.Columns.Add("Student Email", 150);
            listView1.Columns.Add("Instructor First Name", 100);
            listView1.Columns.Add("Instructor Last Name", 100);
            listView1.Columns.Add("Instructor Email", 150);
            listView1.Columns.Add("Transmission", 100);
            listView1.Columns.Add("Date", 120);

            try
            {
                // Load data into Hash table
                var table = new OfflineDatabase();
                table.LoadTables();

                using (var context = new DrivingLessonBookingSystemContext())
                {
                    var lessons = context.Lessons
                        .Where(l => l.Date == lessonDate) 
                        .Select(l => new
                        {
                            // Fields to be included when displaying lessons
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

                    listView1.Items.Clear();

                    if (lessons.Any())
                    {
                        // Check if there is any lessons for particular date
                        foreach (var lesson in lessons)
                        {
                            var item = new ListViewItem(lesson.LessonId.ToString());
                            item.SubItems.Add(lesson.StudentFirstName ?? "");
                            item.SubItems.Add(lesson.StudentLastName ?? "");
                            item.SubItems.Add(lesson.StudentEmail ?? "");
                            item.SubItems.Add(lesson.InstructorFirstName ?? "");
                            item.SubItems.Add(lesson.InstructorLastName ?? "");
                            item.SubItems.Add(lesson.InstructorEmail ?? "");
                            item.SubItems.Add(lesson.CarTransmission ?? "");
                            item.SubItems.Add(lesson.LessonDate.ToShortDateString());

                            listView1.Items.Add(item);
                        }

                        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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



        private void submitButton_Click(object sender, EventArgs e)
        {
            string newLessonId = LessonId.Text;
            invalidLesson.Hide();
            int lessonId;
            if (int.TryParse(newLessonId, out lessonId))
            {
                if (lessonId < 0)
                {
                    invalidLesson.Text = "Lesson ID should be greater than zero";
                    invalidLesson.Show();
                }
                else
                {
                    // Check if lesson id exists in db
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            var result = context.Lessons
                                .Include(l => l.Student)
                                .Include(l => l.Instructor)
                                .Include(l => l.Car)
                                .FirstOrDefault(l => l.LessonId == lessonId);
                            if (result != null)
                            {
                                if (operation == "update")
                                {
                                    // Retrieve StudentEmail, InstructorEmail, and RegistrationNumber
                                    string studentEmail = result.Student.Email;
                                    string instructorEmail = result.Instructor.Email;
                                    string regNo = result.Car.RegistrationNumber;

                                    // Pass these values to the update form
                                    AdminUpdateLesson updateLesson = new AdminUpdateLesson(lessonId, lessonDate, studentEmail, instructorEmail, regNo);

                                    this.Close();

                                    updateLesson.Show();
                                }
                                else if (operation == "delete")
                                {
                                    // Delete from hash table
                                    table.LessonTable.Delete(lessonId);

                                    context.Lessons.Where(l => l.LessonId == lessonId).ExecuteDelete();
                                    MessageBox.Show($"Lesson with id {lessonId} successfully deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                invalidLesson.Text = "Lesson ID not found";
                                invalidLesson.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // For invalid data type inputs
                invalidLesson.Text = "Lesson ID should be a number.";
                invalidLesson.Show();
            }
        }

    }
}
