using System.ComponentModel.DataAnnotations;

namespace CustomerTrainingApp.Data.Models
{
    public class Request 
    {
        // scalar properties
        public int? RequestId { get; set; }
        public int? VendorId { get; set; }
        public string? Vendor_Name { get; set; } 
        public string? Vendor_Mailing_Address { get; set; } 
        public string? Vendor_Telephone_Number { get; set; } 
        public string? Vendor_Email_Address { get; set; } 
        public string? Vendor_Website { get; set; }
        public string? Vendor_POC { get; set; }  
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public DateTime? Training_StartDate { get; set; }
        public DateTime? Training_EndDate { get; set; } 
        public int? Training_DutyHours { get; set; } 
        public int? Training_NonDutyHours { get; set; } 
        public string? Training_PurposeType { get; set; } 
        public int? Training_TypeCode { get; set; } 
        public int? Training_SubTypeCode { get; set; } 
        public int? Training_DeliveryTypeCode { get; set; } 
        public int? Training_DesignationTypeCode { get; set; } 
        public int? Training_Credit { get; set; } 
        public int? Training_CreditTypeCode { get; set; } 
        public int? Training_AccreditionIndicator { get; set; } 
        public DateTime? Continued_Service_Agreement_ExpirationDate { get; set; } 
        public int? Training_Source_TypeCode { get; set; } 
        public string? Individual_or_Group_Training { get; set; } 
        public string? Student_Membership_ID { get; set; } 
        public string? Skill_Learning_Objective { get; set; }

        // Add EmployeeId property as a foreign key
        public int? EmployeeId { get; set; }

        // Add a navigation property for the Employee class
        public Employee? Employee { get; set; }
    }
} 
