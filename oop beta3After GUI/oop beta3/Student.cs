using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_beta3
{
    public class StudentInfo
    {
        public int  StudentId { get; set; }
        public string StudentName { get; set; }

        public StudentInfo(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }
    }
    public class Student : Person
    {
        public static int StudentIdentifier = 100;
        public static string FileName = @"D:\oop beta3\students.json";

        public TrackInfo Track { get; set; } 

        public Student(int id, string name, string address, string phone, string role)
            : base(id, name, address, phone, role)
        { }

        //generate Id Automatically for the student
        public static int GetId()
        {
            var students = ReadStudentFromFile(FileName);
            if (students.Count == 0)
            {
                return StudentIdentifier;
            }
            var lastStudent = students[students.Count - 1];
            return lastStudent.Id + 1;
        }

        //Read student from file
        public static List<Student> ReadStudentFromFile(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Student>();
            }
            return JsonConvert.DeserializeObject<List<Student>>(jsonString);
        }

        //Add student to file
        public static void AddStudentToFile(Student student, string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Student> students = ReadStudentFromFile(fileName);

            File.WriteAllText(fileName, "[]");
            
            if (students.Count != 0)
            {
                bool flag = false;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Name == student.Name && students[i].PhoneNumber == student.PhoneNumber
                    && students[i].Address == student.Address)
                    {
                        flag = true;
                        break;
                    }
                }
            
                if (flag == false)
                { 
                    students.Add(student);
                    SaveStudentToFile(students, fileName);
                }
                else if(flag == true) 
                {
                    SaveStudentToFile(students, fileName);
                    return;
                }
            }
            else
            {
                students.Add(student);
                SaveStudentToFile(students, fileName);
            }

            var credential = new Credential(student.Id, student.Name + "Login", $"{student.Id}Pass");
            Credential.UpdateCredential(credential);
        }

        //Remove student from file
        public static void RemoveStudentToFile(int id, string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            var chickStudent = ValidateStudent(id);
            if(!chickStudent) return;

            List<Student> students = ReadStudentFromFile(fileName);

            File.WriteAllText(fileName, "[]");

            //oop_beta3.Track.DeleteStudent(id);
            var tracks = oop_beta3.Track.ReadTrackFromFile(oop_beta3.Track.FileName);
            File.WriteAllText(oop_beta3.Track.FileName, "[]");
            var trackList = tracks
                .Where(t => t.StudentsInfos.Any(st => st.StudentId == id))
                .ToList();
            if (trackList.Count == 1) trackList[0].StudentsInfos.RemoveAll(st => st.StudentId == id);
            oop_beta3.Track.SaveTrackToFile(tracks, oop_beta3.Track.FileName);

            var credentialText = File.ReadAllText(Credential.FileName);
            var credentials = JsonConvert.DeserializeObject<List<Credential>>(credentialText);
            File.WriteAllText(Credential.FileName, "[]");
            credentials.RemoveAll(c => c.PersonId == id);
            var credentialJson = JsonConvert.SerializeObject(credentials, Formatting.Indented);
            File.WriteAllText(Credential.FileName, credentialJson);

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.RemoveAt(i);
                }
            }

            SaveStudentToFile(students, fileName);
        }

        //update student name from file
        public static void UpdateStudentName(int id, string studentName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Student> students = ReadStudentFromFile(FileName);

            File.WriteAllText(FileName, "[]");
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students[i].Name = studentName;
                }
            }
            SaveStudentToFile(students, FileName);

            var tracks = oop_beta3.Track.ReadTrackFromFile(oop_beta3.Track.FileName);
            File.WriteAllText(oop_beta3.Track.FileName, "[]");
            var trackList = tracks
                .Where(t => t.StudentsInfos.Any(st => st.StudentId == id ))
                .ToList();
            if (trackList.Count == 1) trackList[0].StudentsInfos[0].StudentName = studentName;
            oop_beta3.Track.SaveTrackToFile(tracks, oop_beta3.Track.FileName);
        }

        //save a student to file 
        public static void SaveStudentToFile(List<Student> students, string fileName)
        {
            string jsonstring = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(FileName, jsonstring);
        }

        //check if the student is exist on the file
        public static bool ValidateStudent(int studentId)
        {
            var students = ReadStudentFromFile(FileName);

            var chickStudent = students
                .Where(s => s.Id == studentId)
                .ToList();

            if (chickStudent.Count == 0)
            {
                Console.WriteLine("Invalid Student Number");
                return false;
            }

            return true;
        }

        //get student from file with id with no validation
        public static Student GetStudent(int studentId)
        {
            var students = ReadStudentFromFile(FileName);

            var chickStudent = students
                .Where(s => s.Id == studentId)
                .ToList();

            return chickStudent[0];
        }

        //print the last student entered
        public static void PrintLastStudent()
        {
            var students = ReadStudentFromFile(FileName);
            var lastStudent = students[students.Count - 1];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Student Id: {lastStudent.Id}\nStudent Name: {lastStudent.Name}\nStudent Address: {lastStudent.Address}\nStudent Phone: {lastStudent.PhoneNumber}");
            Console.ResetColor();
        }

        //Print Courses for the student object
        public void PrintStudentCourses()
        {
            var tracks = oop_beta3.Track.ReadTrackFromFile(oop_beta3.Track.FileName);
            var trackList = tracks
                .Where(t => t.StudentsInfos.Any(st => st.StudentId == Id))
                .ToList();
            if (trackList.Count == 1)
            {
                var track = trackList[0];
                Console.WriteLine($"Track Name: {track.TrackName}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var instructor in track.InstructorsWithCourses)
                {
                    Console.WriteLine($"       Course Name: {instructor.CourseName}");
                }
                Console.ResetColor();
            
            }
            else
            {
                Console.WriteLine("Student is not assigned to any track");
                Console.WriteLine("here is all tracks with its Courses");
                oop_beta3.Track.PrintTracksWithCourses();
            }
        }

        //Print instructors with course for the student object
        public void PrintStudentInstructorWithCourse()
        {
            var tracks = oop_beta3.Track.ReadTrackFromFile(oop_beta3.Track.FileName);
            var trackList = tracks
                .Where(t => t.StudentsInfos.Any(st => st.StudentId == Id))
                .ToList();

            if (trackList.Count == 1)
            {
                var track = trackList[0];
                Console.WriteLine($"Track Name: {track.TrackName}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var instructor in track.InstructorsWithCourses)
                {
                    Console.WriteLine($"       Instructor Name: {instructor.InstructorName}       Course Name: {instructor.CourseName}");
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Student is not assigned to any track");
            }
        
        }

        //Print Courses with Track for login student
        public void PrintStudentCoursesWithTrack()
        {
            var tracks = oop_beta3.Track.ReadTrackFromFile(oop_beta3.Track.FileName);
            var trackList = tracks
                .Where(t => t.StudentsInfos.Any(st => st.StudentId == Id))
                .ToList();

            if (trackList.Count == 1)
            {
                var track = trackList[0];
                Console.WriteLine($"Track Name: {track.TrackName}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var instructor in track.InstructorsWithCourses)
                {
                    Console.WriteLine($"       Course Name: {instructor.CourseName}");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student is not assigned to any track");
                Console.ResetColor();
            }
        }
        //Print students with no track
        public static void PrintStudentsWithNoTrack()
        {
            var students = ReadStudentFromFile(FileName);

            var studentList = students
                .Where(s => s.Track == null)
                .ToList();

            if (studentList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Students with no track");
                foreach (var student in studentList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Student Id: {student.Id}       Student Name: {student.Name}");
                }
                Console.ResetColor();
            }
        }

        //Print Students
        public static void PrintStudents()
        {
            var students = ReadStudentFromFile(FileName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Students");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var student in students)
            {
                Console.WriteLine($"Student Id: {student.Id}       Student Name: {student.Name}");
            }
            Console.ResetColor();
        }
        public static string PrintStudentLogin(Student student)
        {
            return $"Student Id: {student.Id}    Student Name: {student.Name}";
        }
    }
}
