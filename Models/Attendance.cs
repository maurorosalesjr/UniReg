namespace UniReg.Models
{
  public class Attendance
    {       
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}