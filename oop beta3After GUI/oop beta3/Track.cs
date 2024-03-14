using Newtonsoft.Json;

namespace oop_beta3;

public class TrackInfo
{
    public int TrackId { get; set; }
    public string TrackName { get; set; }

    public TrackInfo(int trackId, string trackName)
    {
        TrackId = trackId;
        TrackName = trackName;
    }
}

public class Track
{
    public static int TrackIdentifier = 1000;
    public static string FileName = @"D:\oop beta3\tracks.json";
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public List<InstructorWithCourse> InstructorsWithCourses { get; set; }
    public List<StudentInfo> StudentsInfos { get; set; }
    public List<CourseInfo> CoursesInfos { get; set; }
    public List<InstructorInfo> InstructorsInfos { get; set; }

    public Track(int trackId, string trackName, List<InstructorWithCourse> instructorWithCourses, List<StudentInfo> studentInfos, List<CourseInfo> coursesInfos, List<InstructorInfo> instructorsInfos)
    {
        TrackId = trackId;
        TrackName = trackName;
        InstructorsWithCourses = instructorWithCourses;
        StudentsInfos = studentInfos;
        CoursesInfos = coursesInfos;
        InstructorsInfos = instructorsInfos;
    }

    //Read rack from file
    public static List<Track> ReadTrackFromFile(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        if (string.IsNullOrEmpty(jsonString))
        {
            return new List<Track>();
        }
        return JsonConvert.DeserializeObject<List<Track>>(jsonString);
    }

    //Setting the Id automatically
    public static int GetId()
    {
        var tracks = ReadTrackFromFile(FileName);
        if (tracks.Count == 0)
        {
             return 1000;
        }
        return tracks[tracks.Count - 1].TrackId + 1;
        
    }

    //Add Track to file
    public static void AddTrackToFile(Track track, string fileName)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        List<Track> tracks = ReadTrackFromFile(fileName);
        File.WriteAllText(fileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackName == track.TrackName)
            .ToList();
        if (chickTrack.Count != 0)
        {
            Console.WriteLine("Track with the same Name already exist");
            return;
        }

        tracks.Add(track);
        SaveTrackToFile(tracks, fileName);

    }

    //Saving the track to file
    public static void SaveTrackToFile(List<Track> tracks, string fileName)
    {
        var jsonString = JsonConvert.SerializeObject(tracks, Formatting.Indented);
        File.WriteAllText(fileName, jsonString);
    }

    //Delete Certain Track
    public static void DeleteTrack(int trackId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateTrack = ValidateTrack(trackId);
        if(!validateTrack) {return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var trackItem = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();

        //Adding null to the student who enrolled on that Track
        foreach (var track in trackItem)
        {
            foreach (var trackStudentsInfo in track.StudentsInfos)
            {
                var students = Student.ReadStudentFromFile(Student.FileName);
                var student = Student.GetStudent(trackStudentsInfo.StudentId);
                student.Track = null;
                int indexToReplace = students.FindIndex(s => s.Id == trackStudentsInfo.StudentId);
                if (indexToReplace != -1)
                {
                    students[indexToReplace] = student;
                    File.WriteAllText(Student.FileName, "[]");
                    Student.SaveStudentToFile(students, Student.FileName);
                }
            }
        }        
        tracks.RemoveAll(t => t.TrackId == trackId);

        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
        
    }

    //Delete certain Course with specific Track
    public static void DeleteCourse(int trackId, int courseId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateCourse = Course.ValidateCourse(courseId);
        if (!validateCourse) { return; }

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        //tracks.RemoveAll(t => t.InstructorsWithCourses.Any(c => c.CourseId == courseId));

        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                track.InstructorsWithCourses.RemoveAll(c => c.CourseId == courseId);
                track.CoursesInfos.RemoveAll(c => c.CourseId == courseId);
            }
        }

        SaveTrackToFile(tracks, FileName);
        
    }

    //Delete certain Course with All Tracks
    public static void DeleteCourse(int courseId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateCourse = Course.ValidateCourse(courseId);
        if(!validateCourse) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        //tracks.RemoveAll(t => t.InstructorsWithCourses.Any(c => c.CourseId == courseId));
        var courseList = tracks
            .Where(t => t.InstructorsWithCourses.Any(c => c.CourseId == courseId))
            .ToList();

        foreach (var track in tracks)
        {
            track.InstructorsWithCourses.RemoveAll(c => c.CourseId == courseId);
            track.CoursesInfos.RemoveAll(c => c.CourseId == courseId);

        }

        SaveTrackToFile(tracks, FileName);
        
    }

    //Delete certain Instructor with specific Track and a Specific Course
    public static void DeleteInstructor(int trackId, int courseId, int instructorId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateInstructor = Instructor.ValidateInstructor(instructorId);
        if (!validateInstructor) { return; }

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");
        
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                track.InstructorsWithCourses.RemoveAll(i => i.InstructorId == instructorId && i.CourseId == courseId);

            }
        }

        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
        
    }

    //Delete certain Instructor with a specific Tracks 
    public static void DeleteInstructor(int trackId, int instructorId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateInstructor = Instructor.ValidateInstructor(instructorId);
        if (!validateInstructor) { return; }
        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");
        
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                track.InstructorsWithCourses.RemoveAll(i => i.InstructorId == instructorId);

            }
        }

        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
        
    }

    //Delete certain Instructor for all tracks
    public static void DeleteInstructor(int instructorId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateInstructor = Instructor.ValidateInstructor(instructorId);
        if(!validateInstructor) { return;}
        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");
        var instructorList = tracks
            .Where(t => t.InstructorsWithCourses.Any(i => i.InstructorId == instructorId))
            .ToList();

        foreach (var track in tracks)
        {
            foreach (var member in instructorList)
                if(member.TrackId == track.TrackId)
                    track.InstructorsWithCourses.RemoveAll(i => i.InstructorId == instructorId);
        }

        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
    }

    //Delete certain Student with all Tracks
    public static void DeleteStudent(int studentId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var validateStudent = Student.ValidateStudent(studentId);
        if (!validateStudent) { return; }

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");
        tracks.RemoveAll(t => t.StudentsInfos.Any(s => s.StudentId == studentId));
        SaveTrackToFile(tracks, FileName);
    }

    //Update Track Name with a certain Tracks Numbers
    public static void UpdateTrackName(int trackId, string trackName)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var trackExist = ValidateTrack(trackId);
        if(!trackExist) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();

        foreach (var track in tracks)
        {
            foreach (var member in chickTrack)
                if(member.TrackId == track.TrackId)
                    track.TrackName = trackName;
            foreach (var studentInfo in track.StudentsInfos)
            {
                var students = Student.ReadStudentFromFile(Student.FileName);
                var student = Student.GetStudent(studentInfo.StudentId);
                student.Track = new TrackInfo(track.TrackId, trackName);
                int indexToReplace = students.FindIndex(s => s.Id == studentInfo.StudentId);
                if (indexToReplace != -1)
                {
                    students[indexToReplace] = student;
                    File.WriteAllText(Student.FileName, "[]");
                    Student.SaveStudentToFile(students, Student.FileName);
                }
            }
        }
        

        SaveTrackToFile(tracks, FileName);
    }

    //Check if there is a track with the given track Number
    public static bool ValidateTrack(int trackId)
    {
        var tracks = ReadTrackFromFile(FileName);
        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();
        if (chickTrack.Count == 0)
        {
            Console.WriteLine("invalid Track Number");
            return false;
        }

        return true;
    }

    //Update course name and course hour with a certain track number in courseInfo only
    public static void UpdateTrackUpdateCourseName(int trackId, int courseId, string courseName, int totalHours)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var trackExist = ValidateTrack(trackId);
        if (!trackExist) { return; }
        var techCourse = Course.ValidateCourse(courseId);
        if (!techCourse) { return; }

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();
        if (chickTrack.Count == 0)
        {
            Console.WriteLine("Track not found");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        var chickCourse = chickTrack[0].CoursesInfos
            .Where(c => c.CourseId == courseId)
            .ToList();

        if (chickCourse.Count != 1)
        {
            Console.WriteLine("Course not found in that track");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        foreach (var track in chickTrack)
        {
            if (track.TrackId == trackId)
            {
                foreach (var courseInfo in track.CoursesInfos)
                {
                    if (courseInfo.CourseId == courseId)
                    {
                        courseInfo.CourseName = courseName;
                        courseInfo.CourseHours = totalHours;
                    }
                }
            }
        }

        SaveTrackToFile(tracks, FileName);
        
    }

    //Update course name  with a certain track number in courseInfo only
    public static void UpdateTrackUpdateCourseName(int trackId, int courseId, string courseName)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var trackExist = ValidateTrack(trackId);
        if(!trackExist) { return;}
        var techCourse = Course.ValidateCourse(courseId);
        if(!techCourse) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();
        if (chickTrack.Count == 0)
        {
            Console.WriteLine("Track not found");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        var chickCourse = chickTrack[0].CoursesInfos
            .Where(c => c.CourseId == courseId)
            .ToList();

        if (chickCourse.Count != 1)
        {
            Console.WriteLine("Course not found in that track");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        foreach (var track in chickTrack)
        {
            if (track.TrackId == trackId)
            {
                foreach (var courseInfo in track.CoursesInfos)
                {
                    if (courseInfo.CourseId == courseId)
                    {
                        courseInfo.CourseName = courseName;
                    }
                }
            }
        }
        SaveTrackToFile(tracks, FileName);
    }

    //Update course name with updating it in CourseInfo and InstructorWithCourse
    public static void UpdateTrackUpdateCourseNameStudy(int trackId, int courseId, string courseName)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var trackExist = ValidateTrack(trackId);
        if(!trackExist) { return;}
        var techCourse = Course.ValidateCourse(courseId);
        if(!techCourse) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();
        var chickCourse = chickTrack[0].InstructorsWithCourses
            .Where(c => c.CourseId == courseId)
            .ToList();

        if (chickCourse.Count == 0)
        {
            Console.WriteLine("Course not found in that track");
            SaveTrackToFile(tracks, FileName);
            return;
        }
        
        foreach (var track in chickTrack)
        {
            if (track.TrackId == trackId)
            {
                foreach (var instructorWithCourse in track.InstructorsWithCourses)
                {
                    if (instructorWithCourse.CourseId == courseId)
                    {
                        instructorWithCourse.CourseName = courseName;
                    }
                }

                foreach (var courseInfo in track.CoursesInfos)
                {
                    if (courseInfo.CourseId == courseId)
                    {
                        courseInfo.CourseName = courseName;
                    }
                }
            }
        }

        SaveTrackToFile(tracks, FileName);
    }

    //Update course hour with updating it in CourseInfo and InstructorWithCourse
    public static void UpdateTrackUpdateCourseHourStudy(int trackId, int courseId, int courseHour)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var trackExist = ValidateTrack(trackId);
        if(!trackExist) { return;}
        var techCourse = Course.ValidateCourse(courseId);
        if(!techCourse) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();
        var chickCourse = chickTrack[0].InstructorsWithCourses
            .Where(c => c.CourseId == courseId)
            .ToList();

        if (chickCourse.Count == 0)
        {
            Console.WriteLine("Course not found in that track");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        foreach (var track in chickTrack)
        {
            if (track.TrackId == trackId)
            {
                foreach (var instructorWithCourse in track.InstructorsWithCourses)
                {
                    if (instructorWithCourse.CourseId == courseId)
                    {
                        instructorWithCourse.CourseHour = courseHour;
                    }
                }

                foreach (var courseInfo in track.CoursesInfos)
                {
                    if (courseInfo.CourseId == courseId)
                    {
                        courseInfo.CourseHours = courseHour;
                    }
                }
            }
        }

        SaveTrackToFile(tracks, FileName);
    }

    //Update Instructor Name for all courses with all tracks
    public static void UpdateTrackUpdateInstructorName(int instructorId, string instructorName)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var instructorExist = Instructor.ValidateInstructor(instructorId);
        if(!instructorExist) { return;}

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        foreach (var track in tracks)
        {
            foreach (var instructorWithCourse in track.InstructorsWithCourses)
            {
                if (instructorWithCourse.InstructorId == instructorId)
                {
                    instructorWithCourse.InstructorName = instructorName;
                }
            }
        }

        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
    }
    
    //Add student to a certain track
    public static void UpdateTrackAddStudent(int trackId, int studentId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var checkTrack = ValidateTrack(trackId);
        if(!checkTrack) { return;}

        var checkStudent = Student.ValidateStudent(studentId);
        if(!checkStudent) { return;}

        var student = Student.GetStudent(studentId);

        var studentInfo = new StudentInfo(student.Id, student.Name);

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var list = tracks
            .Where(t => t.StudentsInfos.Any(st => st.StudentId == studentId))
            .ToList();

        if (list.Count != 0)
        {
            Console.WriteLine("Student already exist In the given Track Number or another Track");
            SaveTrackToFile(tracks, FileName);
            return;
        }

        var trackItem = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();

        student.Track = new TrackInfo(trackItem[0].TrackId, trackItem[0].TrackName);
        var students = Student.ReadStudentFromFile(Student.FileName);
        int indexToReplace = students.FindIndex(s => s.Id == studentId);

        if (indexToReplace != -1)
        {
            students[indexToReplace] = student;
            File.WriteAllText(Student.FileName, "[]");
            Student.SaveStudentToFile(students, Student.FileName);
        }

        //Student.SaveStudentToFile(stu);

        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                track.StudentsInfos.Add(studentInfo);
                break;
            }

        }

        SaveTrackToFile(tracks, FileName);
        
    }

    //Add Courses to a certain track as CourseInfo
    public static void UpdateTrackAddCourse(int trackId, int courseId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;
        }

        var checkTrack = ValidateTrack(trackId);
        if(!checkTrack) { return;}
        var checkCourse = Course.ValidateCourse(courseId);
        if(!checkCourse) { return;}

        var course = Course.GetCourse(courseId);

        var courseInfo = new CourseInfo(course.Id, course.Name, course.Hours);

        var tracks = ReadTrackFromFile(FileName);


        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                if (track.CoursesInfos.Count == 0)
                {
                    track.CoursesInfos.Add(courseInfo);
                    break;
                }

                foreach (var member in track.CoursesInfos)
                {
                    if (member.CourseId == courseId)
                    {
                        Console.WriteLine("Course already exist on the Given Track Number");
                        SaveTrackToFile(tracks, FileName);
                        return;
                    }
                }

                track.CoursesInfos.Add(courseInfo);
                break;
            }

        }

        SaveTrackToFile(tracks, FileName);
    }

    //Add Courses And Instructor to a certain track as InstructorWithCourse
    public static void UpdateTrackAddCourseAddInstructor(int trackId, int instructorId, int courseId)
    {
        if (!Login.IsAdmin())
        {
            Console.WriteLine("the logged in user isn't admin Or there is no logged in user");
            return;

        }

        var checkTrack = ValidateTrack(trackId);
        if(!checkTrack) { return;}
        var checkInstructor = Instructor.ValidateInstructor(instructorId);
        if(!checkInstructor) { return;}
        var checkCourse = Course.ValidateCourse(courseId);
        if(!checkCourse) { return;}

        var instructor = Instructor.GetInstructor(instructorId);
        var course = Course.GetCourse(courseId);

        var tracks = ReadTrackFromFile(FileName);
        File.WriteAllText(FileName, "[]");

        var list = tracks
            .Where(t => t.TrackId == trackId && t.InstructorsWithCourses.Any(instruct => instruct.InstructorId == instructorId && instruct.CourseId == courseId))
            .ToList();
        if (list.Count != 0)
        {
            Console.WriteLine("Instructor already Teach the same Course on That Track");
            return;
        }
        
        var instructorWithCourse = new InstructorWithCourse(instructor.Id, instructor.Name, course.Id, course.Name, course.Hours);
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                track.InstructorsWithCourses.Add(instructorWithCourse);
                break;
            }
        }
        
        SaveTrackToFile(tracks, FileName);
        UpdateInstructorInfo();
        
    }
    
    //Get the track with the given track number
    public static Track GetTrack(int trackId)
    {
        var tracks = ReadTrackFromFile(FileName);

        var chickTrack = tracks
            .Where(t => t.TrackId == trackId)
            .ToList();

        Track track = null;
        foreach (var track1 in chickTrack)
        {
            track = track1;
        }

        return track;
    }

    //Get the Instructors with each track in instructorInfo list
    public static void UpdateInstructorInfo()
    { 
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            track.InstructorsInfos = new List<InstructorInfo>();
            File.WriteAllText(FileName, "[]");
            foreach (var instructorWithCourse in track.InstructorsWithCourses)
            {
                track.InstructorsInfos.Add(new InstructorInfo(instructorWithCourse.InstructorId, instructorWithCourse.InstructorName));
            }
            SaveTrackToFile(tracks, FileName);

        }

    }

    public static void PrintInstructorInfo(Track track)
    {
        foreach (var instructorInfo in track.InstructorsInfos)
        {
            Console.WriteLine($"Instructor Id: {instructorInfo.InstructorId} Instructor Name: {instructorInfo.InstructorName}");
        }
    }

    //Print the last track entered
    public static void PrintLastTrack()
    {
        var tracks = ReadTrackFromFile(FileName);
        var lastTrack = tracks[tracks.Count - 1];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Track Id: {lastTrack.TrackId} Track Name: {lastTrack.TrackName}");
        Console.ResetColor();
    }

    //Print every tracks with its courses
    public static void PrintTracksWithCourses()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var instructorWithCourse in track.InstructorsWithCourses)
            {
                Console.WriteLine($"        Course Id: {instructorWithCourse.CourseId} Course Name: {instructorWithCourse.CourseName} Course Hours: {instructorWithCourse.CourseHour}");
            }
            Console.ResetColor();
        }
    }

    //Print every courses with specific track
    public static void PrintTracksWithCourses(int trackId)
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var instructorWithCourse in track.InstructorsWithCourses)
                {
                    Console.WriteLine($"        Course Id: {instructorWithCourse.CourseId} Course Name: {instructorWithCourse.CourseName} Course Hours: {instructorWithCourse.CourseHour}");
                }
                Console.ResetColor();
            }
        }
    }

    //Print every courses with Specific Instructor in certain track
    public static void PrintTracksWithCourses(int trackId, int instructorId)
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var instructorWithCourse in track.InstructorsWithCourses)
                {
                    if (instructorWithCourse.InstructorId == instructorId)
                    {
                        Console.WriteLine($"        Course Id: {instructorWithCourse.CourseId} Course Name: {instructorWithCourse.CourseName} Course Hours: {instructorWithCourse.CourseHour}");
                    }
                }
                Console.ResetColor();
            }
        }
    }

    //Print every tracks
    public static void PrintTracks()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
        }
    }

    //Print every tracks with its courses and instructors
    public static void PrintTracksWithCoursesAndInstructors()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var instructorWithCourse in track.InstructorsWithCourses)
            {
                Console.WriteLine($"     Course Id: {instructorWithCourse.CourseId} Course Name: {instructorWithCourse.CourseName} Course Hours: {instructorWithCourse.CourseHour}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var instructorInfo in track.InstructorsInfos)
            {
                Console.WriteLine($"            Instructor Id: {instructorInfo.InstructorId} Instructor Name: {instructorInfo.InstructorName}");
            }
            Console.ResetColor();
        }
    }

    //Print every tracks with its courses and students
    public static void PrintTracksWithCoursesAndStudents()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var courseInfo in track.CoursesInfos)
            {
                Console.WriteLine($"     Course Id: {courseInfo.CourseId} Course Name: {courseInfo.CourseName} Course Hours: {courseInfo.CourseHours}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var studentInfo in track.StudentsInfos)
            {
                Console.WriteLine($"            Student Id: {studentInfo.StudentId} Student Name: {studentInfo.StudentName}");
            }
            Console.ResetColor();
        }
    }

    //Print every tracks with its instructors 
    public static void PrintTracksWithInstructors()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var instructorInfo in track.InstructorsInfos)
            {
                Console.WriteLine($"            Instructor Id: {instructorInfo.InstructorId} Instructor Name: {instructorInfo.InstructorName}");
            }
            Console.ResetColor();
        }
    }

    //Print every instructor with specific track
    public static void PrintTracksWithInstructors(int trackId)
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (var instructorInfo in track.InstructorsInfos)
                {
                    Console.WriteLine($"            Instructor Id: {instructorInfo.InstructorId} Instructor Name: {instructorInfo.InstructorName}");
                }
                Console.ResetColor();
            }
        }
    }

    //Print every tracks with its students
    public static void PrintTracksWithStudents()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var studentInfo in track.StudentsInfos)
            {
                Console.WriteLine($"            Student Id: {studentInfo.StudentId} Student Name: {studentInfo.StudentName}");
            }
            Console.ResetColor();
        }
    }

    //print every student in a certain track
    public static void PrintTracksWithStudents(int trackId)
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            if (track.TrackId == trackId)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (var studentInfo in track.StudentsInfos)
                {
                    Console.WriteLine($"            Student Id: {studentInfo.StudentId} Student Name: {studentInfo.StudentName}");
                }
                Console.ResetColor();
            }
        }
    }
    //Print every tracks with its instructors and students
    public static void PrintTracksWithInstructorsAndStudents()
    {
        var tracks = ReadTrackFromFile(FileName);
        foreach (var track in tracks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Track Id: {track.TrackId} Track Name: {track.TrackName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var instructorInfo in track.InstructorsInfos)
            {
                Console.WriteLine($"            Instructor Id: {instructorInfo.InstructorId} Instructor Name: {instructorInfo.InstructorName}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var studentInfo in track.StudentsInfos)
            {
                Console.WriteLine($"            Student Id: {studentInfo.StudentId} Student Name: {studentInfo.StudentName}");
            }
            Console.ResetColor();
        }
    }
}