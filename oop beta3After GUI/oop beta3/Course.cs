using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace oop_beta3
{
    public class CourseInfo
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseHours { get; set; }

        public CourseInfo(int courseId, string courseName, int courseHours)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseHours = courseHours;
        }
    }
    public class Course
    {
        public static int CourseIdentifier = 500;
        public static string FileName = @"D:\oop beta3\courses.json";

        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        
        public Course(int id, string name, int hours)
        {
            this.Id = id;
            this.Name = name;
            this.Hours = hours;
        }


        //generate Id Automatically for the Course
        public static int GetId()
        {
            var courses = ReadCourseFromFile(FileName);
            if (courses.Count == 0)
            {
                return 500;
            }
            return courses[courses.Count - 1].Id + 1;
            
        }
        
        //Read Course from file
        public static List<Course> ReadCourseFromFile(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Course>();
            }
            return JsonConvert.DeserializeObject<List<Course>>(jsonString);
        }

        //Add Course to file
        public static void AddCourseToFile(Course course, string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Course> courses = ReadCourseFromFile(fileName);
            File.WriteAllText(fileName, "[]");
            if (courses.Count != 0)
            {
                bool flag = false;
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].Name == course.Name && courses[i].Hours == course.Hours)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    courses.Add(course);
                    SaveCourseToFile(courses, fileName);
                }
                else
                {
                    SaveCourseToFile(courses, fileName);
                }
            }
            else
            {
                courses.Add(course);
                SaveCourseToFile(courses, fileName);
            }
        }

        //Remove Course from file
        public static void RemoveCourseFromFile(int id, string fileName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Course> courses = ReadCourseFromFile(fileName);

            File.WriteAllText(fileName, "[]");

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Id == id)
                {
                    courses.RemoveAt(i);
                }
            }
            SaveCourseToFile(courses, fileName);

            var tracks = Track.ReadTrackFromFile(Track.FileName);
            File.WriteAllText(Track.FileName, "[]");

            foreach (var track in tracks)
            {
                track.InstructorsWithCourses.RemoveAll(c => c.CourseId == id);
                track.CoursesInfos.RemoveAll(c => c.CourseId == id);

            }

            Track.SaveTrackToFile(tracks, Track.FileName);
            Track.UpdateInstructorInfo();

        }

        //Update Course in file
        public static void UpdateCourseInfo(int id, string courseName)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Course> courses = ReadCourseFromFile(FileName);

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Id == id)
                {
                    courses[i].Name = courseName;
                }
            }
            SaveCourseToFile(courses, FileName);

            var tracks = Track.ReadTrackFromFile(Track.FileName);
            File.WriteAllText(Track.FileName, "[]");
            foreach (var track in tracks)
            {
                foreach (var course in track.CoursesInfos)
                    if (course.CourseId == id)
                        course.CourseName = courseName;
                foreach (var instructor in track.InstructorsWithCourses)
                    if (instructor.CourseId == id)
                        instructor.CourseName = courseName;
            }
            Track.SaveTrackToFile(tracks, Track.FileName);
        }

        //update course Info
        public static void UpdateCourseInfo(int id, string courseName, int courseHours)
        {
            if (!Login.IsAdmin())
            {
                Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
                return;
            }

            List<Course> courses = ReadCourseFromFile(FileName);

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Id == id)
                {
                    courses[i].Name = courseName;
                    courses[i].Hours = courseHours;
                }
            }
            SaveCourseToFile(courses, FileName);

            var tracks = Track.ReadTrackFromFile(Track.FileName);
            File.WriteAllText(Track.FileName, "[]");
            foreach (var track in tracks)
            {
                foreach (var course in track.CoursesInfos)
                    if (course.CourseId == id)
                    {
                        course.CourseName = courseName;
                        course.CourseHours = courseHours;
                    }
                foreach (var instructor in track.InstructorsWithCourses)
                    if (instructor.CourseId == id)
                    {
                        instructor.CourseName = courseName;
                        instructor.CourseHour = courseHours;
                    }
            }
            Track.SaveTrackToFile(tracks, Track.FileName);
        }

        //Save Course to file
        public static void SaveCourseToFile(List<Course> courses, string fileName)
        {
            string jason = JsonConvert.SerializeObject(courses, Formatting.Indented);
            File.WriteAllText(FileName, jason);
        }

        //check if the course is exist on the file
        public static bool ValidateCourse(int courseId)
        {
            var courses = ReadCourseFromFile(FileName);

            var chickCourse = courses
                .Where(c => c.Id == courseId)
                .ToList();

            if (chickCourse.Count == 0)
            {
                Console.WriteLine("Invalid Course Number");
                return false;
            }
            return true;
        }

        //get course from file with id with no validation
        public static Course GetCourse(int courseId)
        {
            var courses = ReadCourseFromFile(FileName);

            var chickCourse = courses
                .Where(c => c.Id == courseId)
                .ToList();

            return chickCourse[0];
        }

        //print the last course entered
        public static void PrintLastCourse()
        {
            var courses = ReadCourseFromFile(FileName);
            var lastCourse = courses[courses.Count - 1];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Course Id: {lastCourse.Id} \nCourse Name: {lastCourse.Name} \nCourse Hours: {lastCourse.Hours}");
            Console.ResetColor();
        }

        //print the tracks where the course is being teach-ed
        public void PrintTracks()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.CoursesInfos.Any(c => c.CourseId == Id))
                .ToList();

            if (trackList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Tracks for this course");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var track in trackList)
                {
                    Console.WriteLine($"Track Id: {track.TrackId}   Track Name: {track.TrackName}");
                }
                Console.ResetColor();
            }
        }

        //print the instructors who teach this course
        public void PrintInstructors()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsWithCourses.Any(c => c.CourseId == Id))
                .ToList();

            if (trackList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Instructors for this course");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var track in trackList)
                {
                    foreach (var instructor in track.InstructorsWithCourses)
                    {
                        if(instructor.CourseId != Id) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Instructor Id: {instructor.InstructorId}    Instructor Name: {instructor.InstructorName}");
                    }
                }
                Console.ResetColor();
            }
        }

        //print the instructors who teach this course with the tracks
        public void PrintInstructorsWithTracks()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsWithCourses.Any(c => c.CourseId == Id))
                .ToList();

            if (trackList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Instructors for this course");
                Console.ResetColor();
            }
            else
            {
                foreach (var track in trackList)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Track Id: {track.TrackId}   Track Name: {track.TrackName}");
                    foreach (var instructor in track.InstructorsWithCourses)
                    {
                        if (instructor.CourseId != Id) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"        Instructor Id: {instructor.InstructorId}    Instructor Name: {instructor.InstructorName}");
                    }
                }
                Console.ResetColor();
            }
        }

        //print the students who take this course with tracks
        public void PrintStudentsWithTracks()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.CoursesInfos.Any(c => c.CourseId == Id))
                .ToList();

            if (trackList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Students for this course");
                Console.ResetColor();
            }
            else
            {
                foreach (var track in trackList)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Track Id: {track.TrackId}      Track Name: {track.TrackName}");
                    foreach (var student in track.StudentsInfos)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"        Student Id: {student.StudentId}     Student Name: {student.StudentName}");
                    }
                }
                Console.ResetColor();
            }
        }

        //print the students who take this course with tracks with instructors
        public void PrintStudentsWithTracksWithInstructors()
        {
            var tracks = Track.ReadTrackFromFile(Track.FileName);
            var trackList = tracks
                .Where(t => t.InstructorsWithCourses.Any(c => c.CourseId == Id))
                .ToList();

            if (trackList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Students for this course");
                Console.ResetColor();
            }
            else
            {
                foreach (var track in trackList)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Track Id: {track.TrackId}   Track Name: {track.TrackName}");
                    foreach (var instructor in track.InstructorsWithCourses)
                    {
                        if (instructor.CourseId != Id) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    Instructor Id: {instructor.InstructorId}    Instructor Name: {instructor.InstructorName}");

                        foreach (var student in track.StudentsInfos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"      Student Id: {student.StudentId}   Student Name: {student.StudentName}");
                        }
                    }
                    
                }
                Console.ResetColor();
            }
        
        }

        //print all courses
        public static void PrintAllCourses()
        {
            var courses = ReadCourseFromFile(FileName);
            if (courses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Courses");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var course in courses)
                {
                    Console.WriteLine($"Course Id: {course.Id}   Course Name: {course.Name}   Course Hours: {course.Hours}");
                }
                Console.ResetColor();
            }
        }
        
        //print all courses with no tracks
        public static void PrintAllCoursesWithNoTracks()
        {
            var courses = ReadCourseFromFile(FileName);
            var tracks = Track.ReadTrackFromFile(Track.FileName);

            var courseList = courses
                .Where(c => !tracks.Any(t => t.CoursesInfos.Any(ci => ci.CourseId == c.Id)))
                .ToList();

            if (courseList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no Courses with no tracks");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var course in courseList)
                {
                    Console.WriteLine($"Course Id: {course.Id}   Course Name: {course.Name}   Course Hours: {course.Hours}");
                }
                Console.ResetColor();
            }
        }

    }
}
