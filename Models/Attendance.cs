namespace UniReg.Models
{
  public class Attendance
    {       
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}