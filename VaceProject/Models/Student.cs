using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VaceProject.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string ForeName { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime DOB { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}