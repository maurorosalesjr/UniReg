using System.Collections.Generic;

namespace UniReg.Models
{
  public class Course
    {
        public Course()
        {
            this.JoinEntities = new HashSet<Attendance>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Attendance> JoinEntities { get; set; }
    }
}