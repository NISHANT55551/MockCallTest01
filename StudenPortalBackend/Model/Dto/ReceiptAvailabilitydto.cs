namespace StudentPortalBackend.Model.Dto
{
    public class ReceiptAvailabilityDto
    {
        public Guid StudentID { get; set; }
        public string Name { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
