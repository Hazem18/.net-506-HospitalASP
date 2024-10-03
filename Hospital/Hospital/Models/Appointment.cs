namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public DateTime Day { get; set; }
        public TimeOnly Hour { get; set; }
        public string? DoctorName { get; set; }


    }
}
