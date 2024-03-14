using oop_beta3;
using System.Net;

namespace oop_beta3
{
    #region Important Classes you may need to use when running

    //public class TrackWithCourse
    //{
    //    public int TrackId { get; set; }
    //    public string TrackName { get; set; }
    //    public int CourseId { get; set; }
    //    public string CourseName { get; set; }
    //    public int CourseHour { get; set; }

    //    public TrackWithCourse(int trackId, string trackName, int courseId, string courseName, int courseHour)
    //    {
    //        TrackId = trackId;
    //        TrackName = trackName;
    //        CourseId = courseId;
    //        CourseName = courseName;
    //        CourseHour = courseHour;
    //    }
    //}

    //public class TrackWithInstructor
    //{
    //    public int TrackId { get; set; }
    //    public string TrackName { get; set; }
    //    public int InstructorId { get; set; }
    //    public string InstructorName { get; set; }

    //    public TrackWithInstructor(int trackId, string trackName, int instructorId, string instructorName)
    //    {
    //        TrackId = trackId;
    //        TrackName = trackName;
    //        InstructorId = instructorId;
    //        InstructorName = instructorName;
    //    }
    //}

    //public class TrackWithStudent
    //{
    //    public int TrackId { get; set; }
    //    public string TrackName { get; set; }
    //    public int StudentId { get; set; }
    //    public string StudentName { get; set; }

    //    public TrackWithStudent(int trackId, string trackName, int studentId, string studentName)
    //    {
    //        TrackId = trackId;
    //        TrackName = trackName;
    //        StudentId = studentId;
    //        StudentName = studentName;
    //    }
    //}

    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generate Data
            //Login.LogOut();
            //EmptyingFile(Student.FileName);
            //EmptyingFile(Admin.FileName);
            //EmptyingFile(Course.FileName);
            //EmptyingFile(Instructor.FileName);
            //EmptyingFile(Credential.FileName);
            //EmptyingFile(Track.FileName);
            //////EmptyingFile(Login.FileName);

            //Admin admin = new Admin(0, "admin", "alex", "0235354323", "admin");
            //admin.Id = Admin.GetId();
            //Admin.AddAdminToFile(admin, Admin.FileName);

            //var loginAdmin = new Login("adminLogin", "1Pass");
            //Login.SaveLogin(loginAdmin);

            //string[] fullNames = {
            //    "Amr Ali", "Aya Mahmoud", "Hassan Farid", "Nour Ahmed", "Mahmoud Tarek",
            //    "Farida Samir", "Tamer Hossam", "Yasmine Hassan", "Khaled Saleh", "Dalia Kamal",
            //    "Karim Omar", "Laila Adel", "Omar Fahmy", "Shaimaa Magdy", "Ahmed Ibrahim",
            //    "Hoda Ali", "Mohamed Kamel", "Rania Salem", "Sherif Ahmed", "Sara Gamal"
            //};

            //string[] addresses = {
            //    "Cairo", "Alexandria", "Giza", "Shubra El-Kheima", "Port Said",
            //    "Suez", "Luxor", "Asyut", "Ismailia", "Fayoum",
            //    "Zagazig", "Damietta", "Minya", "Beni Suef", "Sohag",
            //    "Hurghada", "Mansoura", "Tanta", "Aswan", "Assiut"
            //};

            //string[] phonesPhones = {
            //    "01234567890", "01567893456", "01098765432", "01215678903", "01543219876",
            //    "01209456781", "01512038476", "01123456789", "01590234876", "01034567812",
            //    "01287654321", "01109876543", "01456789032", "01876543210", "01123456789",
            //    "01234567890", "01567893456", "01098765432", "01215678903", "01543219876"
            //};
            //string roleStudent = "student";

            //for (int i = 0; i < fullNames.Length; i++)
            //{
            //    var student = new Student(0, fullNames[i], addresses[i], phonesPhones[i], roleStudent);
            //    student.Id = Student.GetId();
            //    Student.AddStudentToFile(student, Student.FileName);
            //}

            //string[] fullNamesInstructor = {
            //    "Ahmed Mahmoud", "Fatima Hassan", "Mohamed Ali",
            //    "Nadia Ibrahim", "Karim Abdel-Meguid", "Amina Farid"
            //};

            //string[] instructorAddress = {
            //    "Cairo", "Alexandria", "Giza", "Luxor", "Asyut", "Suez"
            //};

            //string[] newPhones = {
            //    "01123456780", "01567894321", "01098761234", "01215678901", "01543210987", "01209456789"
            //};
            //string roleInstructor = "instructor";

            //for (int i = 0; i < fullNamesInstructor.Length; i++)
            //{
            //    var instructor = new Instructor(0, fullNamesInstructor[i], instructorAddress[i], newPhones[i], roleInstructor);
            //    instructor.Id = Instructor.GetId(Instructor.FileName);
            //    Instructor.AddInstructorToFile(instructor, Instructor.FileName);
            //}

            //string[] programmingCourses = {
            //    "Introduction to Python", "JavaScript Fundamentals", "C# Programming Basics",
            //    "Web Development with HTML and CSS", "Java Programming Essentials",
            //    "Data Structures and Algorithms in C++", "React.js Fundamentals",
            //    "Database Design and SQL", "Full Stack Development with MERN Stack",
            //    "Machine Learning with Python", "iOS App Development with Swift",
            //    "Android App Development with Kotlin", "ASP.NET Core MVC",
            //    "Frontend Frameworks: Angular, Vue, React", "Node.js and Express.js",
            //    "Software Testing and Quality Assurance", "Python for Data Science",
            //    "Blockchain Development with Solidity", "Cloud Computing with AWS",
            //    "Game Development with Unity"
            //};

            //int[] courseHours = {
            //    15, 20, 10, 25, 18,
            //    30, 22, 15, 40, 35,
            //    28, 25, 20, 30, 25,
            //    20, 30, 40, 35, 25
            //};

            //for (int i = 0; i < programmingCourses.Length; i++)
            //{
            //    var course = new Course(0, programmingCourses[i], courseHours[i]);
            //    course.Id = Course.GetId();
            //    Course.AddCourseToFile(course, Course.FileName);
            //}

            //string[] trackNames = {
            //    "Web Development Track", "Data Science and Machine Learning Track",
            //    "Mobile App Development Track", "Full Stack Development Track"
            //};

            //for (int i = 0; i < trackNames.Length; i++)
            //{
            //    var track = new Track(0, trackNames[i], new List<InstructorWithCourse>(), new List<StudentInfo>(), new List<CourseInfo>(), new List<InstructorInfo>());
            //    track.TrackId = Track.GetId();
            //    Track.AddTrackToFile(track, Track.FileName);
            //}

            //Track.UpdateTrackAddStudent(1000, 100);
            //Track.UpdateTrackAddStudent(1000, 101);
            //Track.UpdateTrackAddStudent(1000, 102);
            //Track.UpdateTrackAddStudent(1000, 103);

            //Track.UpdateTrackAddStudent(1001, 104);
            //Track.UpdateTrackAddStudent(1001, 105);
            //Track.UpdateTrackAddStudent(1001, 106);
            //Track.UpdateTrackAddStudent(1001, 107);

            //Track.UpdateTrackAddStudent(1002, 108);
            //Track.UpdateTrackAddStudent(1002, 109);
            //Track.UpdateTrackAddStudent(1002, 110);
            //Track.UpdateTrackAddStudent(1002, 111);

            //Track.UpdateTrackAddStudent(1003, 112);
            //Track.UpdateTrackAddStudent(1003, 113);
            //Track.UpdateTrackAddStudent(1003, 114);
            //Track.UpdateTrackAddStudent(1003, 115);

            //Track.UpdateTrackAddCourse(1000, 500);
            //Track.UpdateTrackAddCourse(1000, 501);
            //Track.UpdateTrackAddCourse(1000, 502);
            //Track.UpdateTrackAddCourse(1000, 503);
            //Track.UpdateTrackAddCourse(1000, 504);
            //Track.UpdateTrackAddCourse(1000, 506);
            //Track.UpdateTrackAddCourse(1000, 507);
            //Track.UpdateTrackAddCourse(1000, 508);
            //Track.UpdateTrackAddCourse(1000, 513);
            //Track.UpdateTrackAddCourse(1000, 514);
            //Track.UpdateTrackAddCourse(1000, 512);

            //Track.UpdateTrackAddCourseAddInstructor(1000, 20, 500);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 21, 501);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 22, 502);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 23, 503);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 24, 504);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 25, 506);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 20, 507);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 21, 508);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 22, 513);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 23, 514);
            //Track.UpdateTrackAddCourseAddInstructor(1000, 24, 512);

            //Track.UpdateTrackAddCourse(1001, 500);
            //Track.UpdateTrackAddCourse(1001, 505);
            //Track.UpdateTrackAddCourse(1001, 509);
            //Track.UpdateTrackAddCourse(1001, 516);

            //Track.UpdateTrackAddCourseAddInstructor(1001, 25, 500);
            //Track.UpdateTrackAddCourseAddInstructor(1001, 20, 505);
            //Track.UpdateTrackAddCourseAddInstructor(1001, 21, 509);
            //Track.UpdateTrackAddCourseAddInstructor(1001, 22, 516);

            //Track.UpdateTrackAddCourse(1002, 510);
            //Track.UpdateTrackAddCourse(1002, 511);
            //Track.UpdateTrackAddCourse(1002, 506);
            //Track.UpdateTrackAddCourse(1002, 514);

            //Track.UpdateTrackAddCourseAddInstructor(1002, 23, 510);
            //Track.UpdateTrackAddCourseAddInstructor(1002, 24, 511);
            //Track.UpdateTrackAddCourseAddInstructor(1002, 25, 506);
            //Track.UpdateTrackAddCourseAddInstructor(1002, 20, 514);

            //Track.UpdateTrackAddCourse(1003, 503);
            //Track.UpdateTrackAddCourse(1003, 501);
            //Track.UpdateTrackAddCourse(1003, 506);
            //Track.UpdateTrackAddCourse(1003, 514);
            //Track.UpdateTrackAddCourse(1003, 507);
            //Track.UpdateTrackAddCourse(1003, 512);
            //Track.UpdateTrackAddCourse(1003, 513);
            //Track.UpdateTrackAddCourse(1003, 508);

            //Track.UpdateTrackAddCourseAddInstructor(1003, 21, 503);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 22, 501);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 23, 506);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 24, 514);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 25, 507);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 20, 512);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 21, 513);
            //Track.UpdateTrackAddCourseAddInstructor(1003, 22, 508);

            #endregion


            #region Gui Design

            Login.LogOut();
            bool continueProgram = true;
            int loginAttemp = 0;
            string? userName = "";
            string? password = "";

            while (loginAttemp < 3)
            {
                LogoWithoutLogin();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Enter your User Name: ");
                Console.ResetColor();
                userName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Enter your password: ");
                Console.ResetColor();
                password = GetPassword();

                var login = new Login(userName, password);
                var checkLogin = Login.ValidateLogin(login);

                if (!checkLogin)
                {
                    Console.WriteLine("Invalid User Name or Password");
                    loginAttemp++;
                    Console.Clear();
                    if (loginAttemp == 3)
                    {
                        Console.WriteLine("this your Last attempt Try again Later");
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    loginAttemp = 0;
                    Login.SaveLogin(login);
                }

                int chooseAttempt = 0;

                while (Login.IsStudent())
                {
                    LogoWithLogin();
                    var student = Student.GetStudent(login.PersonId);
                    CenteredWriteLine(Student.PrintStudentLogin(student));

                    var studentMenu = new[]
                    {
                        "Show Courses.",
                        "Show Tracks With Courses.",
                        "Show Tracks With Instructors And Courses."
                    };

                    PrintMenu(studentMenu);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Choose your Number: ");
                    Console.ResetColor();
                    var studentInput = Console.ReadLine();
                    var studentChoose = int.Parse(studentInput);

                    if (studentChoose > studentMenu.Length)
                    {
                        Console.WriteLine("Invalid Choose for Number");
                        chooseAttempt++;
                        //Console.Clear();

                        if (chooseAttempt == 3)
                        {
                            Console.WriteLine("this your Last attempt As student Try login again");
                            Console.WriteLine("Student signed out");
                            break;
                        }
                    }

                    if (studentChoose == 1)
                    {
                        chooseAttempt = 0;
                        student.PrintStudentCourses();
                        Console.Write("Enter any key to go student Menu  ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (studentChoose == 2)
                    {
                        chooseAttempt = 0;
                        student.PrintStudentCoursesWithTrack();
                        Console.Write("Enter any key to go student Menu  ");
                        Console.ReadLine();
                        Console.Clear();

                    }
                    else if (studentChoose == 3)
                    {
                        chooseAttempt = 0;
                        student.PrintStudentInstructorWithCourse();
                        Console.Write("Enter any key to go student Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (studentChoose == 0)
                    {
                        chooseAttempt = 0;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        CenteredWriteLine("Student signed out");
                        Console.ResetColor();
                        Login.LogOut();
                        break;
                    }

                }

                while (Login.IsInstructor())
                {
                    LogoWithLogin();
                    var instructor = Instructor.GetInstructor(login.PersonId);
                    CenteredWriteLine(Instructor.PrintInstructorLogin(instructor));

                    var instructorMenu = new[]
                    {
                        "Show Tracks",
                        "Show Courses With Students.",
                        "Show Track with Courses.",
                        "Show Track With Students."
                    };

                    PrintMenu(instructorMenu);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Choose your Number: ");
                    Console.ResetColor();
                    var instructorInput = Console.ReadLine();
                    var instructorChoose = int.Parse(instructorInput);

                    if (instructorChoose > instructorMenu.Length)
                    {
                        Console.WriteLine("Invalid Choose for Number");
                        chooseAttempt++;
                        //Console.Clear();

                        if (chooseAttempt == 3)
                        {
                            Console.WriteLine("this your Last attempt As Instructor Try login again");
                            Console.WriteLine("Instructor signed out");
                            break;
                        }
                    }

                    if (instructorChoose == 1)
                    {
                        chooseAttempt = 0;
                        instructor.PrintTracks();
                        Console.Write("Enter any key to go Instructor Menu  ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (instructorChoose == 2)
                    {
                        chooseAttempt = 0;
                        instructor.PrintCourseWithStudents();
                        Console.Write("Enter any key to go Instructor Menu  ");
                        Console.ReadLine();
                        Console.Clear();

                    }
                    else if (instructorChoose == 3)
                    {
                        chooseAttempt = 0;
                        instructor.PrintTrackWithCourses();
                        Console.Write("Enter any key to go Instructor Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (instructorChoose == 4)
                    {
                        chooseAttempt = 0;
                        instructor.PrintTrackWithStudents();
                        Console.Write("Enter any key to go Instructor Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (instructorChoose == 0)
                    {
                        chooseAttempt = 0;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        CenteredWriteLine("Instructor signed out");
                        Console.ResetColor();
                        Login.LogOut();
                        break;
                    }
                }

                while (Login.IsAdmin())
                {
                    LogoWithLogin();
                    var admin = Admin.GetAdmin(login.PersonId);
                    CenteredWriteLine(Admin.PrintAdminLogin(admin));

                    var adminMenu = new[]
                    {
                        "Show All students",
                        "Show All students with Tracks",
                        "Show All students with Courses",
                        "Show All students with Courses With Instructors",
                        "Show All students with No Tracks",
                        "Show All instructors",
                        "Show All instructors with Tracks",
                        "Show All instructors with No Tracks",
                        "Show All Courses",
                        "Show All Courses with Tracks",
                        "Show All Courses with Tracks with Instructors",
                        "Show All Courses with No Tracks",
                        "show All Tracks ",
                        "Add new Track",
                        "Add new Course",
                        "Add new Instructor",
                        "Add new Student",
                        "Add Student to Track",
                        "Add Course to Track Without Instructor",
                        "Add Course And Instructor to Track",
                        "Delete Track",
                        "Delete Course From ITI",
                        "Delete Instructor From ITI",
                        "Delete Student From ITI",
                        "Delete Course From All Tracks",
                        "Delete Instructor From All Tracks",
                        "Delete Student From Track",
                        "Delete Course From a Track",
                        "Delete Instructor From a Track",
                        "Delete Instructor From a Course From Track"

                    };

                    PrintMenu(adminMenu);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Choose your Number: ");
                    Console.ResetColor();
                    var adminInput = Console.ReadLine();
                    var adminChoose = int.Parse(adminInput);

                    if (adminChoose > adminMenu.Length)
                    {
                        Console.WriteLine("Invalid Choose for Number");
                        chooseAttempt++;
                        //Console.Clear();

                        if (chooseAttempt == 3)
                        {
                            Console.WriteLine("this your Last attempt As Admin Try login again");
                            Console.WriteLine("Admin signed out");
                            break;
                        }
                    }

                    if (adminChoose == 1)
                    {
                        chooseAttempt = 0;
                        oop_beta3.Student.PrintStudents();
                        Console.Write("Enter any key to go Admin Menu  ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 2)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithStudents();
                        Console.Write("Enter any key to go Admin Menu  ");
                        Console.ReadLine();
                        Console.Clear();

                    }

                    else if (adminChoose == 3)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithCoursesAndStudents();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 4)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithCoursesAndInstructors();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 5)
                    {
                        chooseAttempt = 0;
                        oop_beta3.Student.PrintStudentsWithNoTrack();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 6)
                    {
                        chooseAttempt = 0;
                        Instructor.PrintAllInstructors();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 7)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithInstructors();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 8)
                    {
                        chooseAttempt = 0;
                        oop_beta3.Instructor.PrintInstructorsWithNoTrack();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 9)
                    {
                        chooseAttempt = 0;
                        Course.PrintAllCourses();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    
                    else if (adminChoose == 10)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithCourses();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 11)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracksWithCoursesAndInstructors();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 12)
                    {
                        chooseAttempt = 0;
                        oop_beta3.Course.PrintAllCoursesWithNoTracks();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 13)
                    {
                        chooseAttempt = 0;
                        Track.PrintTracks();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 14)
                    {
                        chooseAttempt = 0;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Name: ");
                        Console.ResetColor();
                        var trackName = Console.ReadLine();
                        Track track = new Track(0, trackName, new List<InstructorWithCourse>(), new List<StudentInfo>(), new List<CourseInfo>(), new List<InstructorInfo>());
                        track.TrackId = Track.GetId();
                        Track.AddTrackToFile(track, Track.FileName);
                        Track.PrintLastTrack();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 15)
                    {
                        chooseAttempt = 0;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Name: ");
                        Console.ResetColor();
                        var courseName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Hours: ");
                        Console.ResetColor();
                        var courseHours = int.Parse(Console.ReadLine());

                        Course course = new Course(0, courseName, courseHours);
                        course.Id = Course.GetId();
                        Course.AddCourseToFile(course, Course.FileName);

                        Course.PrintLastCourse();
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 16)
                    {
                        chooseAttempt = 0;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Name: ");
                        Console.ResetColor();
                        var instructorName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Address: ");
                        Console.ResetColor();
                        var instructorAddress = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Phone Number: ");
                        Console.ResetColor();
                        var instructorPhoneNumber = Console.ReadLine();
                        
                        var instructor = new Instructor(0, instructorName, instructorAddress, instructorPhoneNumber, "instructor");
                        instructor.Id = Instructor.GetId(Instructor.FileName);
                        Instructor.AddInstructorToFile(instructor, Instructor.FileName);
                        
                        Instructor.PrintLastInstructor();

                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 17)
                    {
                        chooseAttempt = 0;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Name: ");
                        Console.ResetColor();
                        var studentName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Address: ");
                        Console.ResetColor();
                        var studentAddress = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Phone Number: ");
                        Console.ResetColor();
                        var studentPhoneNumber = Console.ReadLine();

                        var student = new Student(0, studentName, studentAddress, studentPhoneNumber, "student");
                        student.Id = Student.GetId();
                        Student.AddStudentToFile(student, Student.FileName);

                        Student.PrintLastStudent();

                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 18)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are Student with no Tracks ");
                        oop_beta3.Student.PrintStudentsWithNoTrack();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Id: ");
                        Console.ResetColor();
                        var studentId = int.Parse(Console.ReadLine());

                        Track.UpdateTrackAddStudent(trackId, studentId);
                        Console.WriteLine("Student Added to Track Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 19)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Courses");
                        oop_beta3.Course.PrintAllCourses();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        Track.UpdateTrackAddCourse(trackId, courseId);
                        Console.WriteLine("Course Added to Track Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 20)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Courses ");
                        oop_beta3.Course.PrintAllCourses();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Instructors ");
                        oop_beta3.Instructor.PrintAllInstructors();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Id: ");
                        Console.ResetColor();
                        var instructorId = int.Parse(Console.ReadLine());

                        Track.UpdateTrackAddCourseAddInstructor(trackId, instructorId, courseId);
                        Console.WriteLine("Course And Instructor Added to Track Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 21)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        Track.DeleteTrack(trackId);
                        Console.WriteLine("Track Deleted Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();

                    }

                    else if (adminChoose == 22)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all Courses Exist");
                        oop_beta3.Course.PrintAllCourses();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        Course.RemoveCourseFromFile(courseId, Course.FileName);
                        Console.WriteLine("Course Deleted Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 23)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all Instructors Exist");
                        oop_beta3.Instructor.PrintAllInstructors();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Id: ");
                        Console.ResetColor();
                        var instructorId = int.Parse(Console.ReadLine());

                        oop_beta3.Instructor.RemoveInstructorToFile(instructorId, Instructor.FileName);
                        Console.WriteLine("Instructor Deleted Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (adminChoose == 24)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all Students Exist");
                        oop_beta3.Student.PrintStudents();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Id: ");
                        Console.ResetColor();
                        var studentId = int.Parse(Console.ReadLine());

                        oop_beta3.Student.RemoveStudentToFile(studentId, Student.FileName);
                        Console.WriteLine("Student Deleted Successfully");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();

                    }

                    else if (adminChoose == 25)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all Courses Exist");
                        oop_beta3.Course.PrintAllCourses();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        Track.DeleteCourse(courseId);
                        Console.WriteLine("Course Deleted Successfully From All Tracks");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();

                    }
                    else if (adminChoose == 26)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all Instructors Exist");
                        oop_beta3.Instructor.PrintAllInstructors();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Id: ");
                        Console.ResetColor();
                        var instructorId = int.Parse(Console.ReadLine());

                        Track.DeleteInstructor(instructorId);
                        Console.WriteLine("Instructor Deleted Successfully From All Tracks");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (adminChoose == 28)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Course Exist On that track");
                        Track.PrintTracksWithCourses(trackId);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        Track.DeleteCourse(trackId, courseId);
                        Console.WriteLine("Student Deleted Successfully From Track");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (adminChoose == 27)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Students Exist On that Track");
                        Track.PrintTracksWithStudents(trackId);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Student Id: ");
                        Console.ResetColor();
                        var studentId = int.Parse(Console.ReadLine());

                        Track.DeleteStudent(studentId);
                        Console.WriteLine("Student Deleted Successfully From Track");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (adminChoose == 29)
                    {
                        chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Instructors Exist on that track");
                        oop_beta3.Track.PrintTracksWithInstructors(trackId);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Id: ");
                        Console.ResetColor();
                        var instructorId = int.Parse(Console.ReadLine());

                        Track.DeleteInstructor(trackId, instructorId);
                        Console.WriteLine("Instructor Deleted Successfully From Track");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    
                    }
                    else if (adminChoose == 30)
                    {
                                                chooseAttempt = 0;
                        CenteredWriteLine("the following are all tracks Exist");
                        Track.PrintTracks();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Track Id: ");
                        Console.ResetColor();
                        var trackId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Instructors Exist on that track");
                        oop_beta3.Track.PrintTracksWithInstructors(trackId);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Instructor Id: ");
                        Console.ResetColor();
                        var instructorId = int.Parse(Console.ReadLine());

                        CenteredWriteLine("the following are all Courses Exist On that track For That Instructor");
                        Track.PrintTracksWithCourses(trackId, instructorId);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Course Id: ");
                        Console.ResetColor();
                        var courseId = int.Parse(Console.ReadLine());

                        Track.DeleteInstructor(trackId,  courseId, instructorId);
                        Console.WriteLine("Instructor Deleted Successfully From Course From Track");
                        Console.Write("Enter any key to go Admin Menu ");
                        Console.ReadLine();
                        Console.Clear();
                    
                    }
                    else if (adminChoose == 0)
                    {
                        chooseAttempt = 0;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        CenteredWriteLine("Admin signed out");
                        Console.ResetColor();
                        Login.LogOut();
                        break;
                    
                    }

                }
            }

            #endregion


        }

        public static void EmptyingFile(string fileName)
        {
            File.WriteAllText(fileName, "[]");
        }

        //hash password when user enter it
        static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Check if the key pressed is not Enter or any other special key
                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Tab)
                {
                    // Append the character to the password
                    password += key.KeyChar;

                    // Display '*' for each character
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Handle backspace by removing the last character from the password
                    password = password.Substring(0, password.Length - 1);

                    // Move the cursor back and overwrite the character with a space
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);

            // Move to the next line after the user presses Enter
            Console.WriteLine();

            return password;
        }

        public static void LogoWithoutLogin()
        {
            Console.WriteLine(@"
                  *    *******   *          ****    *   *     ****    *******    *******    *           *
                  *       *      *         *    *    * *     *    *      *       *          **         **
                  *       *      *          *         *       *          *       *          * *       * *
                  *       *      *           *        *        *         *       *******    *  *     *  *
                  *       *      *            *       *         *        *       *          *   *   *   *
                  *       *      *         *   *      *      *   *       *       *          *    * *    *
                  *       *      *          ***       *       ***        *       *******    *     *     *
            ");
        }

        public static void LogoWithLogin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                  *    *******   *          ****    *   *     ****    *******    *******    *           *
                  *       *      *         *    *    * *     *    *      *       *          **         **
                  *       *      *          *         *       *          *       *          * *       * *
                  *       *      *           *        *        *         *       *******    *  *     *  *
                  *       *      *            *       *         *        *       *          *   *   *   *
                  *       *      *         *   *      *      *   *       *       *          *    * *    *
                  *       *      *          ***       *       ***        *       *******    *     *     *
            ");
            Console.ResetColor();
        }

        //print the text at the middle of the screen
        static void CenteredWriteLine(string text)
        {
            int width = Console.WindowWidth;
            int padding = (width - text.Length) / 2;

            Console.WriteLine(text.PadLeft(padding + text.Length));
        }

        static void PrintMenu(string[] menu)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"#[{i + 1}]      {menu[i]}");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("For going back to the Login  menu enter:  0");

        }   
    }
}
