using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaceProject.ViewModels.ManageStudent
{
    public class AddStudentViewModel
    {
        public string ForeName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

    }
}