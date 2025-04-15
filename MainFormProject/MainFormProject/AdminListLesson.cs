using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;

namespace MainFormProject
{
    public partial class AdminListLesson : Form
    {
        private string userType;
        public AdminListLesson(string userType)
        {
            InitializeComponent();
            this.userType = userType;
        }

        public void AdminListLesson_Load(object sender, EventArgs e)
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

            if (userType == "admin")
            {
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();

                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var lessons = context.Lessons
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

                        listView1.Items.Clear();

                        if (lessons.Any())
                        {
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
                            MessageBox.Show("Nolessons present.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (userType == "student")
            {
                StudentMenu studentMenu = new StudentMenu();

                this.Close();

                studentMenu.Show();
            } else if (userType == "instructor")
            {
                InstructorMenu instructorMenu = new InstructorMenu();

                this.Close();

                instructorMenu.Show();
            }
            else
            {
                LessonHandler lessonHandlerMenu = new LessonHandler();

                this.Close();

                lessonHandlerMenu.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
