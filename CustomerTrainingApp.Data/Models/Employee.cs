using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTrainingApp.Data.Models
{
    public class Employee
    {
        // scalar properties
        public int? EmployeeId { get; set; }
        public string? Agency_Code { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Middle_Initial { get; set; }
        public string? Home_Address { get; set; }
        public string? Home_Telephone { get; set; }
        public string? Position_Level { get; set; }
        public string? Organization_Mailing_Address { get; set; }
        public string? Office_Telephone { get; set; }
        public string? Work_Email_Address { get; set; }
        public string? Position_Title { get; set; }
        public bool? IsSpecialAccomodationNeeded { get; set; }
        public string? SpecialAccomodation_Details { get; set; }
        public string? Education_Level { get; set; }
        public string? Pay_Plan { get; set; }
        public int? Series { get; set; }
        public int? Grade { get; set; }
        public int? Step { get; set; }

        public ICollection<Request>? Requests { get; set; } 
    }
}
