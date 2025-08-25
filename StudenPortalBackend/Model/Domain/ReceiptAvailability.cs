using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortalBackend.Model.Domain
{
    public class ReceiptAvailability
    {
        [Key]
        public Guid StudentID { get; set; }           // Unique identifier for the student
        public string Name { get; set; }              // Student's full name
        public DateTime PaymentDate { get; set; }     // Date of fee payment
    }
}

