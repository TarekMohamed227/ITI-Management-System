using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace oop_beta3
{
    public class InstructorInfo
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        

        public InstructorInfo(int instructorId, string instructorName)
        {
            InstructorId = instructorId;
            InstructorName = instructorName;
        }
    }

    public class Instructor : Person
    {
        public static int InstructorIdentiFier = 20;
        public static string FileName = @"D:\oop beta3\instructors.json";

        public Instructor(int id, string name, string address, string phone, string role)
            :base(id, name,address, phone, role)
        {
             
        }

        //Generating the instructor Id Automatically
        public static int GetId(string fileName)
        {
            var instructors = ReadInstructorFromFile(fileName);
            if (instructors.Count == 0)
            {
                return InstructorIdentiFier;
            }
            return instructors[instructors.Count - 1].Id + 1;
        }
        
        public static int GetInstructorIdCounter(List<Instructor> instructors)
        {
            return instructors.Count > 0 ? instructors.Count : 0;
        }


        //Reading the Instructor from the file
        public static List<Instructor> ReadInstructorFromFile(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Instructor>();
            }
            return JsonConvert.DeserializeObject<List<Instructor>>(jsonString);
        }

        //Adding the Instructor to the file
        public static void AddInstructorToFile(Instructor instructor, string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Instructor> instructors = ReadInstructorFromFile(fileName);

            File.WriteAllText(fileName, "[]");

            if (instructors.Count != 0)
            {
                bool flag = false;

                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].Name == instructor.Name && instructors[i].PhoneNumber == instructor.PhoneNumber
                    && instructors[i].Address == instructor.Address)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    instructors.Add(instructor);
                    SaveInstructorToFile(instructors, fileName);
                }
                else if (flag)
                {
                    SaveInstructorToFile(instructors, fileName);
                    return;
                }
            }
            else
            {
                instructors.Add(instructor);
                SaveInstructorToFile(instructors, fileName);
            }
            var credential = new Credential(instructor.Id, instructor.Name + "Login", $"{instructor.Id}pass");
            Credential.UpdateCredential(credential);
        }


        //Remove the Instructor from the file and the entire ITI system
        public static void RemoveInstructorToFile(int id , string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Instructor> instructors = ReadInstructorFromFile(fileName);

            File.WriteAllText(fileName, "[]");

            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].Id == id)
                {
                    instructors.RemoveAt(i);
                }
            }

            SaveInstructorToFile(instructors, fileName);

            var tracks = Track.ReadTrackFromFile(Track.FileName);
            File.WriteAllText(Track.FileName, "[]");

            foreach (var track in tracks)
            {

                track.InstructorsWithCourses.RemoveAll(i => i.InstructorId == id);
                track.InstructorsInfos.RemoveAll(i => i.InstructorId == id);
            }
            
            var credentialsString = File.ReadAllText(Credential.FileName);
            var credentials = JsonConvert.DeserializeObject<List<Credential>>(credentialsString);
            File.WriteAllText(Credential.FileName, "[]");
            credentials.RemoveAll(c => c.PersonId == id);
            var credentialObject = JsonConvert.SerializeObject(credentials, Formatting.Indented);
            File.WriteAllText(Credential.FileName, credentialObject);

            //Track.UpdateInstructorInfo();
            Track.SaveTrackToFile(tracks, Track.FileName);
        }

        //Updating the Instructor Name in the file
        public static void  UpdateInstructorName (int id ,string instructorName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            var checkInstructor = ValidateInstructor(id);
            if(!checkInstructor) return;

            List<Instructor> instructors = ReadInstructorFromFile(FileName);

            File.WriteAllText(FileName, "[]");

            foreach (var instructor in instructors)
            {
                if (instructor.Id == id)
                {
                    instructor.Name = instructorName;
                    break;
                }
            }

            SaveInstructorToFile(instructors, FileName);
            Track.UpdateTrackUpdateInstructorName(id, instructorName);
        }

        //Saving the Instructor to the file
        public static void SaveInstructorToFile(List<Instructor> instructors, string fileName)
        {
            string jsonstring = JsonConvert.SerializeObject(instructors, Formatting.Indented);
            File.WriteAllText(FileName, jsonstring);
        }

        //Checking if the Instructor is exist or not in the file
        public static bool ValidateInstructor(int instructorId)
        {
            var instructors = ReadInstructorFromFile(FileName);

            var list = instructors
                .Where(i => i.Id == instructorId)
                .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Instructor Number");
                return false;
            }

            return true;
        }

        //Getting the Instructor from the file
        public static Instructor GetInstructor(int instructorId)
        {
            var instructors = ReadInstructorFromFile(FileName);

            var chickInstructor = instructors
                .Where(i => i.Id == instructorId)
                .ToList();

            return chickInstructor[0];
        }

        //printing the last instructor entered
        public static void PrintLastInstructor()
        {
            var instructors = ReadInstructorFromFile(FileName);
            var lastInstructor = instructors[instructors.Count - 1];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"instructorID :{lastInstructor.Id} \nInstructorName :{lastInstructor.Name} \nInstructorPhoneNumber :{lastInstructor.PhoneNumber} \nInstructorAddress :{lastInstructor.Address}");
            Console.ResetColor();
        }

        //printing the track and students of the instructor
        public void PrintTrackWithStudents()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsInfos.Any(i => i.InstructorId == Id))
                .ToList();

            foreach (var track in trackList)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Track Name: {track.TrackName}");
                Console.ResetColor();
                foreach (var student in track.StudentsInfos)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Student Id: {student.StudentId}   Student Name: {student.StudentName}");
                    Console.ResetColor();
                }
            }
        
        }

        //printing the track and courses of the instructor
        public void PrintTrackWithCourses()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsInfos.Any(i => i.InstructorId == Id))
                .ToList();

            foreach (var track in trackList)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Track Name: {track.TrackName}");
                Console.ResetColor();

                foreach (var course in track.InstructorsWithCourses)
                {
                    if (course.InstructorId != Id) continue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Course Id: {course.CourseId} Course Name: {course.CourseName}");
                    Console.ResetColor();

                }
            }
        }

        //Printing the course and students of the instructor
        public void PrintCourseWithStudents()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsInfos.Any(i => i.InstructorId == Id))
                .ToList();

            foreach (var track in trackList)
            {
                
                foreach (var course in track.InstructorsWithCourses)
                {
                    if (course.InstructorId != Id) continue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Course Id: {course.CourseId} Course Name: {course.CourseName}");
                    Console.ResetColor();

                    foreach (var student in track.StudentsInfos)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"        Student Id: {student.StudentId}   Student Name: {student.StudentName}");
                        Console.ResetColor();
                    }
                }
            }
        }

        //Printing the tracks where the instructor teaches
        public void PrintTracks()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsInfos.Any(i => i.InstructorId == Id))
                .ToList();
            foreach (var track in trackList)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"TrackId :{track.TrackId}  TrackName :{track.TrackName}");
                Console.ResetColor();
            }
        }

        //Printing all the instructors
        public static void PrintAllInstructors()
        {
            var instructors = ReadInstructorFromFile(FileName);
            foreach (var instructor in instructors)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"InstructorId :{instructor.Id}  InstructorName :{instructor.Name}");
                Console.ResetColor();
            }
        }

        //Print the instructor logged in
        public static string PrintInstructorLogin(Instructor instructor)
        {
            return $"Instructor Id :{instructor.Id}  Instructor Name :{instructor.Name}";
        }

        //Print instructors with no track
        public static void PrintInstructorsWithNoTrack()
        {
            var instructors = ReadInstructorFromFile(FileName);
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var instructorsWithNoTrack = instructors
                .Where(i => !tracks.Any(t => t.InstructorsInfos.Any(ii => ii.InstructorId == i.Id)))
                .ToList();

            foreach (var instructor in instructorsWithNoTrack)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"InstructorId :{instructor.Id}  InstructorName :{instructor.Name}");
                Console.ResetColor();
            }
        }

    }
}
