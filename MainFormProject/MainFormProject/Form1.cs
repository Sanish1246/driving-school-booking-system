using MainFormProject.Context;
using MainFormProject.Models;
using MainFormProject.CSVHeaders;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;


namespace MainFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string option = comboBox1.Text;
            errorLabel.Hide();

            switch(option)
            {
                // File upload for student/car/instructor/lessons
                case "Lesson":
                    UploadLessonData();
                    break;
                case "Student":
                    UploadStudentData();
                    break;
                case "Instructor":
                    UploadInstructorData();
                    break;
                case "Car":
                    UploadCarData();
                    break;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            LoginChoice loginChoice = new LoginChoice();

            this.Hide();

            loginChoice.Show();
        }

        public bool UploadStudentData()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileName = dataPath.Text;
            var fullPath = Path.Combine(projectDirectory, "Data", fileName);
            var studentFileUploadSuccess = false;

            if (File.Exists(fullPath))
            {
                // read csv
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };
                using (var reader = new StreamReader(fullPath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<StudentMap>();
                    try
                    {
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            var isStudentUpdated = false;
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = csv.GetRecord<Student>();
                                var email = record.Email;

                                // Check if email is already present in database; emails should be unique
                                if (!CheckStudentEmailExistence(email))
                                {
                                    // Valid email (email doesn't exists)
                                    context.Students.Add(record);
                                    isStudentUpdated = true;
                                }
                            }

                            if (isStudentUpdated)
                            {
                                context.SaveChanges();
                                MessageBox.Show($"Records from {fileName} have been successfully been uploaded. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            studentFileUploadSuccess = true;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return studentFileUploadSuccess;
                    }
                }
            }
            else
            {
                errorLabel.Text="File doesn't exist";
                errorLabel.Show();
            }

            return studentFileUploadSuccess;
        }

        private bool UploadInstructorData()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileName = dataPath.Text;
            var fullPath = Path.Combine(projectDirectory, "Data", fileName);
            var instructorFileUploadSuccess = false;

            if (File.Exists(fullPath))
            {
                // read csv
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };
                using (var reader = new StreamReader(fullPath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<InstructorMap>();
                    try
                    {
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            var isInstructorUpdated = false;
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = csv.GetRecord<Instructor>();
                                var email = record.Email;

                                // Check if email is already present in database; emails should be unique
                                if (!CheckInstructorEmailExistence(email))
                                {
                                    // Valid email (email doesn't exists)
                                    context.Instructors.Add(record);
                                    isInstructorUpdated = true;
                                }
                            }

                            if (isInstructorUpdated)
                            {
                                context.SaveChanges();
                                MessageBox.Show($"Records from {fileName} have been successfully been uploaded. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            instructorFileUploadSuccess = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                errorLabel.Text = "File doesn't exist";
                errorLabel.Show();
            }

            return instructorFileUploadSuccess;
        }

        private bool UploadCarData()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileName = dataPath.Text;
            var fullPath = Path.Combine(projectDirectory, "Data", fileName);
            var carFileUploadSuccess = false;

            if (File.Exists(fullPath))
            {
                // read csv
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };
                using (var reader = new StreamReader(fullPath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<CarMap>();
                    try
                    {
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            var isCarUpdated = false;
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = csv.GetRecord<Car>();
                                var carReg = record.RegistrationNumber;

                                // Check if car reg is already present in database; car reg should be unique
                                if (IsUnique(carReg))
                                {
                                    // Valid car (car reg is unique)
                                    context.Cars.Add(record);
                                    isCarUpdated = true;
                                }
                            }

                            if (isCarUpdated)
                            {
                                context.SaveChanges();
                                MessageBox.Show($"Records from {fileName} have been successfully been uploaded. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            carFileUploadSuccess = true;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return carFileUploadSuccess;
                    }
                }
            }
            else
            {
                errorLabel.Text = "File doesn't exist";
                errorLabel.Show();
            }

            return carFileUploadSuccess;
        }


        private bool UploadLessonData()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileName = dataPath.Text;
            var fullPath = Path.Combine(projectDirectory, "Data", fileName);
            var lessonFileUploadSuccess = false;

            if (File.Exists(fullPath))
            {
                // read csv
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };
                using (var reader = new StreamReader(fullPath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<LessonMap>();
                    try
                    {
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                // Allow duplicates
                                var record = csv.GetRecord<Lesson>();
                                context.Lessons.Add(record);
                            }
                            context.SaveChanges();
                            MessageBox.Show($"Records from {fileName} have been successfully been uploaded. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lessonFileUploadSuccess = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Processing failed: {e.Message}");
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return lessonFileUploadSuccess;
                    }
                }
            }
            else
            {
                errorLabel.Text = "File doesn't exist";
                errorLabel.Show();
            }
            return lessonFileUploadSuccess;
        }

        public static bool CheckStudentEmailExistence(string email)
        {
            // Connect with Database
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Students.Any(s => s.Email == email);
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
