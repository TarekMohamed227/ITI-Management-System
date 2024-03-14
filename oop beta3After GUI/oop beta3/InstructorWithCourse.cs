namespace oop_beta3;

public class InstructorWithCourse
{
    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public int CourseHour { get; set; }

    public InstructorWithCourse(int instructorId, string instructorName, int courseId, string courseName, int courseHour)
    {
        InstructorId = instructorId;
        InstructorName = instructorName;
        CourseId = courseId;
        CourseName = courseName;
        CourseHour = courseHour;
    }

}