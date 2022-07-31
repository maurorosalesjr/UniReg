using System.Collections.Generic;

namespace UniReg.Models
{
    public class Student
    {
        public Student()
        {
            this.JoinEntities = new HashSet<Attendance>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int EnrollmentDate { get; set; }

        public virtual ICollection<Attendance> JoinEntities { get;}
    }
}